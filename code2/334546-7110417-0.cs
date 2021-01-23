        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            RootFrame.Opacity = 100;
            RootFrame.Navigated -= RootFrame_Navigated;
        }
        private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back &&
                e.Uri.OriginalString.Contains("ThePage.xaml"))
            {
                RootFrame.Opacity = 0;
                RootFrame.Navigated += RootFrame_Navigated;
            }
        }
