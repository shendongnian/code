    public void UnregisterListeners()
    {
        foreach(Listener listener in Listeners)
        {
            listener.Invoeritem = null;
        }
        Listeners.Clear();
    }
