    public void IgnoreExceptions(Action act)
    {
       try
       {
          act.Invoke();
       }
       catch { }
    }
