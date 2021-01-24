    private async void ProgressbarStart(int Maximum)
    {
        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
        () =>
        {
            imgloadprogress.Visibility = Windows.UI.Xaml.Visibility.Visible;
            imgloadprogress.Maximum = Maximum;
            imgloadprogress.Minimum = 0;
            imgloadprogress.Value = 0;
        });
    }
    private async void ProgressBarProgress()
    {
        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
       () =>
       {
           if (imgloadprogress.Value + 1 > imgloadprogress.Maximum)
               imgloadprogress.Maximum = imgloadprogress.Maximum + 10;
           imgloadprogress.Value += 1;
       });
    }
