    void AddControlCommandExecuted() {
        var container = // resolve your DI container here
        // Now use the container to resolve your "child" view. For example,
        // if using UnityContainer it could go like this:
        var view = container.Resolve<ChildView>();
        // Of course you can also resolve the ViewModel if your program is
        // "ViewModel-first" instead of "View-first".
        // Does the ChildViewModel need some properties to be set?
        var viewModel = (ChildViewModel)view.DataContext;
        viewModel.StringProperty = "blah";
        // Now get a reference to the region in your View which will host
        // the "child" views.
        var regionManager = container.Resolve<IRegionManager>();
        var region = regionManager.Regions["MyRegionName"];
        // Finally add the view to the region. You can do it manually, you
        // can use the concept of "navigation" if your MVVM framework has one
        // (I 'm using Prism, which does), etc etc.
        region.Add(view);
    }
