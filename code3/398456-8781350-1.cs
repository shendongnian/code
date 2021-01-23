    public void DoWork<T>(IEnumerable<BaseObject<T>> objects) 
        where T : BaseDefinition
    {
        foreach(var baseObj in objects)
        {
            foreach(var baseDef in baseObj.Objects)
            {
                // do some work
            }
        }
    }
