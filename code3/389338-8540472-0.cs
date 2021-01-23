    public object[] GetValues(int connectionId, int readerId, object[] values)
    {
        lock (StaticServer.PublicLock)
        {
           var values = StaticServer.GetValues(connectionId, readerId);
           return values;
        }
    }
