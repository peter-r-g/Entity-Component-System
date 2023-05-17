﻿using Sandbox;
using System;

namespace EntityComponentSystem;

/// <summary>
/// Contains configuration options for <see cref="ECS"/>.
/// </summary>
public sealed class ECSConfiguration
{
	/// <summary>
	/// Returns a default instance of <see cref="ECSConfiguration"/>.
	/// </summary>
	public static ECSConfiguration Default => new();

	internal Func<IComponent, bool>? SystemResolver { get; private set; }
	/// <summary>
	/// Whether or not to use query caching.
	/// </summary>
	internal bool UseCaching { get; private set; } = true;

	/// <summary>
	/// Initializes a default instance of <see cref="ECSConfiguration"/>.
	/// </summary>
	internal ECSConfiguration() { }
	/// <summary>
	/// Initializes a cloned instance of <see cref="ECSConfiguration"/>.
	/// </summary>
	/// <param name="other"></param>
	internal ECSConfiguration( ECSConfiguration other )
	{
		SystemResolver = other.SystemResolver;
		UseCaching = other.UseCaching;
	}

	/// <summary>
	/// Sets whether or not to use query caching.
	/// </summary>
	/// <param name="useCaching">Whether or not to use query caching.</param>
	/// <returns>The same instance of <see cref="ECSConfiguration"/>.</returns>
	public ECSConfiguration WithCaching( bool useCaching )
	{
		UseCaching = useCaching;
		return this;
	}

	public ECSConfiguration WithSystemResolver( Func<IComponent, bool> systemResolver )
	/// <summary>
	/// Sets the callback method to resolve custom systems that should be executed.
	/// </summary>
	/// <param name="systemResolver">The callback method to resolve custom systems that should be executed.</param>
	/// <returns>The same instance of <see cref="ECSConfiguration"/>.</returns>
	{
		SystemResolver = systemResolver;
		return this;
	}
}
