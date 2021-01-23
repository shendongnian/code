    public Tupel<int, int> GetTime() 
    { 
        DateTime dt = DateTime.Now;
        return Tupel.Create(dt.Hour, dt.Minute);
    }
    
