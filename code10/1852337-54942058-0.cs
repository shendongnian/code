    private void SafeCallProcess(int j) 
    {
       try 
       {
          Process (j);
       }
       catch(Exception e)
       {
          // deal with it
       }
    }
