    public static void RaiseLoadedEvent(FrameworkElement element)
    {
        MethodInfo eventMethod = typeof(FrameworkElement).GetMethod("OnLoaded",
            BindingFlags.Instance | BindingFlags.NonPublic);
        RoutedEventArgs args = new RoutedEventArgs(FrameworkElement.LoadedEvent);
        eventMethod.Invoke(element, new object[] { args });
    }
