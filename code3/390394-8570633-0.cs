    public void processException(Exception ex)
    {
       if (ex is System.Threading.ThreadAbortException)
       {
          // Do something
       }
       else if (ex is AnotherException)
       {
          // Do something else
       }
    }
