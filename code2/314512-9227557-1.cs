    /// <summary>
    /// A behaviour class which attaches the current scoped <see cref="IRegionManager"/> to views and their data contexts.
    /// </summary>
    public class RegionAwareBehaviour : RegionBehavior
    {
    	/// <summary>
    	/// The key to identify this behaviour.
    	/// </summary>
    	public const string RegionAwareBehaviourKey = "RegionAwareBehaviour";
    
    	/// <summary>
    	/// Override this method to perform the logic after the behaviour has been attached.
    	/// </summary>
    	protected override void OnAttach()
    	{
    		Region.Views.CollectionChanged += RegionViewsChanged;
    	}
    
    	private void RegionViewsChanged(object sender, NotifyCollectionChangedEventArgs e)
    	{
    		Contract.Requires<ArgumentNullException>(e != null);
    
    		if (e.NewItems != null)
    			foreach (var item in e.NewItems)
    				MakeViewAware(item);
    	}
    
    	private void MakeViewAware(object view)
    	{
    		Contract.Requires<ArgumentNullException>(view != null);
    
    		var frameworkElement = view as FrameworkElement;
    		if (frameworkElement != null)
    			MakeDataContextAware(frameworkElement);
    
    		MakeAware(view);
    	}
    
    	private void MakeDataContextAware(FrameworkElement frameworkElement)
    	{
    		Contract.Requires<ArgumentNullException>(frameworkElement != null);
    
    		if (frameworkElement.DataContext != null)
    			MakeAware(frameworkElement.DataContext);
    	}
    
    	private void MakeAware(object target)
    	{
    		Contract.Requires<ArgumentNullException>(target != null);
    
    		var scope = target as IRegionManagerAware;
    		if (scope != null)
    			scope.RegionManager = Region.RegionManager;
    	}
    }
