    public static readonly RoutedEvent ModelClickEvent = EventManager.RegisterRoutedEvent(
            "ModelClick", RoutingStrategy.Bubble, typeof(ModelClickEventHandler), typeof(Window));
    // Provide CLR accessors for the event
    public event ModelClickEventHandler FadeIn
    {
        add { AddHandler(ModelClickEvent, value); }
        remove { RemoveHandler(ModelClickEvent, value); }
    }
    
    // This method raises the Tap event
    void RaiseTapEvent()
    {
        ModelClickEventArgs newEventArgs = new ModelClickEventArgs();
        newEventArgs.MyString = "some string";
        RaiseEvent(newEventArgs);
    }
