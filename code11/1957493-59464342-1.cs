    if (instance.eventDictionary.TryGetValue(eventName, out var thisEvent))
    {
        thisEvent.Add(listener);
    }
    else
    {
        instance.eventDictionary.Add
        (
            eventName,
            new List<Action<GameObject, int, int, int, int> {listener}
        );
    }
