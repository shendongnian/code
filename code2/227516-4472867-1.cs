    public static void SetInitialFocus(UIElement element, bool value)
    {
        Control c = element as Control;
        if (c != null && value)
        {
            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                // This could also be added in the Loaded event of the MainPage
                HtmlPage.Plugin.Focus();
                c.Loaded -= loadedEventHandler;
                c.Focus();
            });
            c.Loaded += loadedEventHandler;
        }
    }
