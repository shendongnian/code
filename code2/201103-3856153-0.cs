    private int count;
    
    public int Count 
    {
      get 
      {
        return count;
      }
    }
    
    public void Increment
    {
      Interlocked.Increment(count);
    }
