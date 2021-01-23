    var viewManager = AppContext.Current.ViewService.GetViewManager("Main");
    var views = viewManager.OpenViews;
    for (int i = views.Count -1; i < views.Count; i--)
    {
        if(i == -1)
        {
            return;
        }
        viewManager.CloseView(_views[i]);
    }
