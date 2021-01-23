    public static bool FireLoadedEvent(FrameworkElement element)
    {
        MethodInfo eventMethod;
        RoutedEventArgs args;
        eventMethod = typeof (FrameworkElement).GetMethod("OnLoaded", BindingFlags.Instance | BindingFlags.NonPublic);
        if (eventMethod == null)
        {
            return false;
        }
        args = new RoutedEventArgs(FrameworkElement.LoadedEvent);
        try
        {
            eventMethod.Invoke(element, new object[] { args });
        }
        catch
        {
            return false;
        }
        return true;
    }
