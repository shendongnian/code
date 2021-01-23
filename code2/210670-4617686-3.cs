    private static void MethodA_PrecalcEndTime()
    {
      int cnt = 0;
      var doneTime = DateTime.Now.AddSeconds(1);
      var startDT = CurrentTimeGetter.Now;
      while (CurrentTimeGetter.Now <= doneTime)                            
      {           
        cnt++;
      }
      var endDT = DateTime.Now;
      Console.WriteLine("Time Taken: {0,30} Total Counted: {1,20}", endDT.Subtract(startDT), cnt);                        }                             
    }
