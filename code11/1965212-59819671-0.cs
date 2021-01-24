    if (!ApplicationContext.ContactsViewModel.IsWindowOpen)
    {
        ApplicationContext.CurrentChatView.Dispatcher.Invoke(() =>
        {
            if (!Window.IsVisible)
            {
                Window.Show();
            }
            
            if (Window.WindowState == WindowState.Minimized)
            {
                Window.WindowState = WindowState.Normal;
            }
            
            Window.Activate();
            Window.Topmost = true;  // important
            Window.Topmost = false; // important
            Window.Focus();         // important
        });
    }
