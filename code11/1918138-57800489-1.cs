    private void tabMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl) //if this event fired from TabControl then enter
        {
                //show loading logo
                LoadingLogo.Visibility = Visibility.Visible;
                //hide the loading logo with lower priority, so that it closes after UI finished loading
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(()=> { LoadingLogo.Visibility = Visibility.Collapsed; }));
        }
    }
