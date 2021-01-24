        private int _barID;
        private async void ShowCompactView()
        {
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                
                frame.Navigate(typeof(Bar));
                _barID = ApplicationView.GetForCurrentView().Id;
                Window.Current.Content = frame;
                Window.Current.Activate();
                ApplicationView.GetForCurrentView().Title = "CompactOverlay Window";
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsViewModeAsync(sliderID, ApplicationViewMode.CompactOverlay);
        }
