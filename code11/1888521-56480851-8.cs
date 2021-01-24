    private void InvokeCommunication()
    {
        var listener = CommunicationListeners.Count > 0 ? CommunicationListeners[0] : null;
        if (listener == null) return;
        listener.OnServerCommunication();
        CommunicationListeners.RemoveAt(0);
    }
    private void InvokeSceneSync()
    {
        var listener = SceneSyncListeners.Count > 0 ? SceneSyncListeners[0] : null;
        if (listener == null) return;
        listener.OnServerSceneSync();
        SceneSyncListeners.RemoveAt(0);
    }
    
