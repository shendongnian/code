    delegate void EventListener(object eventInfo);
    List<(System.Type Type, Delegate Listener, EventListener Wrapper)> eventListeners;
    public void RegisterListener<T>(System.Action<T> listener)
    {
        System.Type eventType = typeof(T);
        if (eventListeners == null)
        {
            eventListeners = new List<(System.Type, Delegate, EventListener)>();
        }
		if (!eventListeners.Any(entry => entry.Type.Equals(eventType) &&
            entry.Listener.Equals(listener))) {
			eventListeners.Add((eventType, listener, ei => listener((T)ei)));
		}
    }
    public void UnregisterListener<T>(System.Action<T> listener)
    {
        System.Type eventType = typeof(T);
        if (eventListeners == null)
        {
            return;
        }
        var toRemove = eventListeners.FirstOrDefault(entry => entry.Type.Equals(eventType) &&
            entry.Listener.Equals(listener));
        eventListeners.Remove(toRemove);
    }
