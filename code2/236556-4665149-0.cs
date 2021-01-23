    object dictLock = new object();
    internal List<string> GetListOfEntities()
    {            
        lock (dictLock)
        {
            return ModelFacade._totalListOfStkObjects.Keys.ToList();
        }
    }
