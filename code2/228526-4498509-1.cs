    public static readonly RoutedEvent SelectedEvent =
    EventManager.RegisterRoutedEvent(
    "Selected", RoutingStrategy.Bubble,
    typeof(SelectionChangedEventHandler),
    typeof(MyUserControl));
    
    //add remove handlers
    public event SelectionChangedEventHandler Selected
    {
        add { AddHandler(SelectedEvent, value); }
        remove { RemoveHandler(SelectedEvent, value); }
    }
