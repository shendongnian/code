    void AddView()
    {
        IRegion region = this._regionManager.Regions["RegionName"];
        object presentView = region.GetView( "ViewName" );
        if ( presentView == null )
        {
            var view = _container.Resolve<View>( );
            region.Add( view, "ViewName" );
        }
    }
    
    void RemoveView()
    {
        IRegion region = this._regionManager.Regions["RegionName"];
        object presentView = region.GetView( "ViewName" );
        if ( presentView != null )
        {
            region.Remove( presentView );
        }
    }
