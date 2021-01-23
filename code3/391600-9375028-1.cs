    for (Int32 i = 0; i < app.Session.SyncObjects.Count; i++)
    {
        _syncObj = app.Session.SyncObjects[1];
        _syncObj.SyncEnd +=_syncObj_SyncEnd;
    }
    _syncObj.Start(); 
