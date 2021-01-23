    using System.Diagnostics;
    using System.Threading.Tasks;
    class Program
    {
       static void Main(string[] args)
       {
         DoStuffService svc = new DoStuffService();
         svc.Start();//bool res = svc.Start() 
         Trace.WriteLine("333333333333333");
       }
    }
    public class DoStuffService
    {
       public Task<bool> MyTask;
       public bool Start()
       {
          MyTask = Task.Factory.StartNew<bool>
            (() =>
            {
              Trace.WriteLine("111111111");
              
              return LongRunningOperation();;
            });
          return MyTask.Result;
        }
        private bool LongRunningOperation()
        {
          System.Threading.Thread.Sleep(3000);
          Trace.WriteLine("2222222222");
          return true;
        }
    }
