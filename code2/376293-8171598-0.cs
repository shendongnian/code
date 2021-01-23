    public void LoopThrough<T>(IEnumerable<T> entityList) where T : EntityBase
    {
        foreach(T entity in entityList) 
        {
            DoSomething(entity as EntityBase);  
        }
    }
