    public int[] GetTime() 
    { 
        DateTime dt = DateTime.Now;
        return new[] { dt.Hour, dt.Minute};
    }
