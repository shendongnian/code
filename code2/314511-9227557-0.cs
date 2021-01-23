    /// <summary>
    /// An interface which is aware of the current region manager.
    /// </summary>
    public interface IRegionManagerAware
    {
    	/// <summary>
    	/// Gets or sets the current region manager.
    	/// </summary>
    	/// <value>
    	/// The current region manager.
    	/// </value>
    	IRegionManager RegionManager { get; set; }
    }
