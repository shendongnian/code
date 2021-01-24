    private async void OnInactivity(object sender, EventArgs e)
    {
        // remember mouse position
        _inactiveMousePosition = Mouse.GetPosition(this);
        // set UI on inactivity
        Debug.WriteLine ( DateTime.Now.ToString("HH:mm:ss.fffffff") + " Inactivity" ) ;
        await System.Windows.Application.Current.Dispatcher.InvokeAsync(new Action(() =>
        {
            Grid1.Visibility = Visibility.Collapsed;
            videoplayer.Play();
            Grid2.Visibility = Visibility.Visible;
        }));
    }
