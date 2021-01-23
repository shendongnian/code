    PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
    if (frame != null)
    {
        PhoneApplicationPage page = frame.Content as PhoneApplicationPage;
    
        if (page != null)
        {
            SystemTray.SetIsVisible(page, false);
        }
    }
