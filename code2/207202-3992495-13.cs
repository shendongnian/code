    public Tuple<int, int> GetTime() 
    { 
        DateTime dt = DateTime.Now;
        return Tuple.Create(dt.Hour, dt.Minute);
    }
    
