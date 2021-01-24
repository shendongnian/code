    _container.RegisterType(viewType, region);
    view = _container.Resolve(viewType, region);
    (view as System.Windows.FrameworkElement).DataContext = viewModel;
    IRegion r = new Region();
    r.Name = region;
    _regionManager.Regions.Add(r);
    _regionManager.RegisterViewWithRegion(region, view.GetType());
    _regionManager.Regions[region].Add(view);
