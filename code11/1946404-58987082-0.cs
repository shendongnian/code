      protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
               ........
                Window.Current.Activate();
            }
            //screen resolution
            string heightsize = DisplayInformation.GetForCurrentView().ScreenHeightInRawPixels.ToString();
            string widthsize = DisplayInformation.GetForCurrentView().ScreenWidthInRawPixels.ToString();
            Size mysize = new Size(Convert.ToDouble(widthsize), Convert.ToDouble(heightsize));
            ApplicationView.PreferredLaunchViewSize = mysize;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }
