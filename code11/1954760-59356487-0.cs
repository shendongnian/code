    try
    {
        var obj= new MyDbObject()
        {
            ID = ObjectId.GenerateNewId(),
            // many properties including objects, and lists of objects
        };
        var metaCollection = db.GetCollection<MyDbObject>("MyDbObject");
        await metaCollection.InsertOneAsync(obj);
        _logger.Info("Saved with ID " + obj.ID);//line 107 in stack trace where the error is coming from
    }
    catch (Exception e)
    {
        _logger.Error($"Failed to save metastore with error {e}");
        throw;//line 121 in stacktrace where the error is being rethrown
    }
