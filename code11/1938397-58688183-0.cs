        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                Window.Current.Content = rootFrame;
            }
            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                MaximizeWindowOnLoad();
                Window.Current.Activate();
            }
        }
        private void MaximizeWindowOnLoad()
        {
            var view = DisplayInformation.GetForCurrentView();
            var resolution = new Size(view.ScreenWidthInRawPixels, view.ScreenHeightInRawPixels);
            var scale = view.ResolutionScale == ResolutionScale.Invalid ? 1 : view.RawPixelsPerViewPixel;
            var bounds = new Size(resolution.Width / scale, resolution.Height / scale);
            ApplicationView.GetForCurrentView().SetPreferredMinSize(bounds);
            ApplicationView.PreferredLaunchViewSize = new Size(bounds.Width, bounds.Height);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
           Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TryResizeView(bounds);
        }
