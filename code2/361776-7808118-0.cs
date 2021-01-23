    public Update<T>(T toUpdate)
    {
        // Code from link above with YourEntity = T
        
        List<object> myRetrievedKeyValues = new List<object>();
        foreach (var keyName in keyNames)
            myRetrievedKeyValues.Add(toUpdate.GetType().GetProperty(keyName)
                .GetValue(toUpdate, null));
        var retrievedItem = _entities.Set<T>().Find(myRetrievedKeyValues.ToArray());
        _entities.Entry(retrievedItem).CurrentValues.SetValues(toUpdate);
    }
