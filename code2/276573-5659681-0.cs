    IRegion region = this._regionManager.Regions["MainRegion"];
    object mainView = region.GetView( MainViewName );
    if ( mainView == null )
    {
        var view = _container.ResolveSessionRelatedView<MainView>( );
        region.Add( view, MainViewName );
    }
