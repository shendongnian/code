    public virtual T Get(int id)
    {
        if(T is IIDInterface)
           return ObjectSet.First(x => ((IIDInterface)x).Id == id) 
        return default(T);
    }
