        async void PlayMediaNavigation()
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                musicPlayerNavigation.Play();
            });
        }
        
          
        private async void Botan_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            PlayMediaNavigation();
        }
        
