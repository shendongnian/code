    protected override void OnActivated(IActivatedEventArgs e)
    {
        if (e.Kind == ActivationKind.Protocol)
        {
            Frame rootFrame = CreateRootFrame();
    
            if (rootFrame.Content == null)
            {
                if (!rootFrame.Navigate(typeof(MainPage)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            var arg = e as ProtocolActivatedEventArgs;
            if (arg.Uri.LocalPath == "full")
            {
                var view = ApplicationView.GetForCurrentView();
                if (!view.IsFullScreenMode)
                {
                    view.TryEnterFullScreenMode();
                }
            }
    
            var p = rootFrame.Content as MainPage;
            p.NavigateToPageWithParameter(3, e);
    
            // Ensure the current window is active
            Window.Current.Activate();
        }
    }
