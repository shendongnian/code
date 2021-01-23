    public event RoutedEventHandler Loaded
    {
        add
        {
            base.AddHandler(LoadedEvent, value, false);
        }
        remove
        {
            base.RemoveHandler(LoadedEvent, value);
        }
    }
