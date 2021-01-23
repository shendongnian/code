    public bool IsEmpty
    {
       get { /* always costs 10s here */  }
    }
   
    public int Count
    {
       get { /* always costs 15s here, no matter Count is 0 or 1 or 2... */  }
    }
