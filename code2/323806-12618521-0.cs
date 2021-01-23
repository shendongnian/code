    /// <summary>
    /// Removes all event handlers subscribed to the specified routed event from the specified element.
    /// </summary>
    /// <param name="element">The UI element on which the routed event is defined.</param>
    /// <param name="routedEvent">The routed event for which to remove the event handlers.</param>
    public static void RemoveRoutedEventHandlers(UIElement element, RoutedEvent routedEvent)
    {
        // Get the EventHandlersStore instance which holds event handlers for the specified element.
        // The EventHandlersStore class is declared as internal.
        var eventHandlersStoreProperty = typeof(UIElement).GetProperty(
            "EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
        object eventHandlersStore = eventHandlersStoreProperty.GetValue(element, null);
        // Invoke the GetRoutedEventHandlers method on the EventHandlersStore instance 
        // for getting an array of the subscribed event handlers.
        var getRoutedEventHandlers = eventHandlersStore.GetType().GetMethod(
            "GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var routedEventHandlers = (RoutedEventHandlerInfo[])getRoutedEventHandlers.Invoke(
            eventHandlersStore, new object[] { routedEvent });
            
        // Iteratively remove all routed event handlers from the element.
        foreach (var routedEventHandler in routedEventHandlers)
            element.RemoveHandler(routedEvent, routedEventHandler.Handler);
    }
