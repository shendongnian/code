    public void IgnoreExceptions(Action act)
    {
       try
       {
          Act.Invoke();
       }
       catch(Exception exc){}
    }
