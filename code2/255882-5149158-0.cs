    public void Initialize()
    {
        // Register view objects with Prism Region
        m_RegionManager.RegisterViewWithRegion("TaskButtonRegion", typeof(ModuleBTaskButton));
        m_RegionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(ModuleBView));
        m_RegionManager.RegisterViewWithRegion("RibbonRegion", typeof(ModuleBRibbonTab));
    }
