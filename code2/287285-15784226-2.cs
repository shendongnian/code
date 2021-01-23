    using System.Diagnostics;
    using System.Threading.Tasks;
    
    class Program
    {
    
      static void Main(string[] args)
      {
        DoStuffService svc = new DoStuffService();
        svc.Start().Wait();//bool res = svc.Start() 
        Trace.WriteLine("333333333333333");
      }
    }
    public class DoStuffService
    {
      public Task Start()
      {
        return Task.Factory.StartNew
          (() =>
          {
            Trace.WriteLine("111111111");
            LongRunningOperation(); ;
          });
      }
      private void LongRunningOperation()
      {
        System.Threading.Thread.Sleep(3000);
        Trace.WriteLine("2222222222");
      }
    }
