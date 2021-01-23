    PrintSystemJobInfo info;
    
    void thread1()
    {
       lock(info)
       {
          info.dothings();
       }
    }
    
    void thread2()
    {
       lock(info)
       {
          info.getthings();
       }
    }
