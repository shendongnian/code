    AutoResetEvent hasItem;
    AutoResetEvent doneWithItem;
    int jobitem;
    public void ThreadOne()
    {
     int i;
     while(true)
      {
      //SomeLongJob
      i++;
      jobitem = i;
      hasItem.Set();
      doneWithItem.WaitOne();
      }
    }
    public void ThreadTwo()
    {
     while(true)
     {
      hasItem.WaitOne();
      ProcessItem(jobitem);
      doneWithItem.Set();
      
     }
    }
