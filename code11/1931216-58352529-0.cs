    private async void Instance_NetworkChanged(object sender, EventArgs e)
    {
     await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
      {
        shellFrame.Navigate(typeof(page));
      });
    }
