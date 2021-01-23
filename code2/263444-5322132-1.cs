    class processmanagement
    {
      Process p;
      
      public void startprocess()
      {
        p = new Process();
      }
    
      public void killprocess()
      {
        if(p!=null)
          p.kill();
      }
    }
