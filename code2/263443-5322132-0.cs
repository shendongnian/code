    class processmanagement
    {
      Process p;
      
      public Process startprocess()
      {
        p = new Process();
      }
    
      public void killprocess(Process p1)
      {
        p = p1;
        if(p!=null)
          p.kill();
      }
    }
