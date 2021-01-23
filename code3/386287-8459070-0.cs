     public class PerformanceClass
     {
         public event EventHandler<PerformanceEventArgs> DataUpdate;
         ....
         public void CPUThread()
         {
            int i = 0;
            while (i++ < 5)
            {
                string cpuCount = getCPUUsage();
                OnDataUpdate(cpuCount);
                System.Threading.Thread.Sleep(500);
            }   
         }
         private void OnDataUpdate(string data)
         { 
              var handler = DataUpdate;
              if (handler != null)
              {
                   handler(this, new PerformanceEventArgs(data));
              }
         }
     }
     public class PerformanceEventArgs: EventArgs
     {
           public string Data { get; private set; }
           public PerformanceEventArgs(string data)
           {
                Data = data;
           }
     }
