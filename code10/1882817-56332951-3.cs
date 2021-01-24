    private async void OnActivity(object sender, PreProcessInputEventArgs e)
    {
        var inputEventArgs = e.StagingItem.Input;
        switch ( inputEventArgs.RoutedEvent.Name )
        {
            case "PreviewGotKeyboardFocus":
            case "PreviewKeyboardInputProviderAcquireFocus":
            case "KeyboardInputProviderAcquireFocus":
            case "LostKeyboardFocus":
            case "GotKeyboardFocus":
                return ;
        }
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
