    private async void OnActivity(object sender, PreProcessInputEventArgs e)
    {
        var inputEventArgs = e.StagingItem.Input;
        if (inputEventArgs is System.Windows.Input.MouseEventArgs || inputEventArgs is KeyboardEventArgs)
        {
            if (e.StagingItem.Input is System.Windows.Input.MouseEventArgs)
            {
                var mouseEventArgs = (System.Windows.Input.MouseEventArgs)e.StagingItem.Input;
                if (!(
                    mouseEventArgs.LeftButton == MouseButtonState.Pressed ||
                    mouseEventArgs.RightButton == MouseButtonState.Pressed ||
                    mouseEventArgs.MiddleButton == MouseButtonState.Pressed ||
                    mouseEventArgs.XButton1 == MouseButtonState.Pressed ||
                    mouseEventArgs.XButton2 == MouseButtonState.Pressed
                    || _inactiveMousePosition != mouseEventArgs.GetPosition(this)
                    ))
                {
                    return;
                }
            }
            Debug.WriteLine ( DateTime.Now.ToString("HH:mm:ss.fffffff") + " Activity " + inputEventArgs.RoutedEvent.ToString() ) ;
            // set UI on activity
            await System.Windows.Application.Current.Dispatcher.InvokeAsync(new Action(() =>
            {
                videoplayer.Stop();
                Grid1.Visibility = Visibility.Visible;
                Grid2.Visibility = Visibility.Hidden;
            }));
            _activityTimer.Stop();
            _activityTimer.Start();
        }
    }
