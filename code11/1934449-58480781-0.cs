    public EventHandler event ObjectEnabled;
    void OnEnabled()
    {
        ObjectEnabled?.Invoke(this, new EventArgs());
    }
