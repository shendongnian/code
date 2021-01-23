    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Data;
    using System.Threading.Tasks;
    
    
    namespace ConsoleApplication5
    {
      class VirtualTerminal
      {
        public VirtualTerminal(int a, int b) { }
        public bool Bind() { System.Threading.Thread.Sleep(10000); return true; }
      }
      class Program
      {
    
        static void Main(string[] args)
        {
          VirtualTerminal terminal = new VirtualTerminal(80, 25);
    
          Func<bool> func = () => terminal.Bind() ;
          Task<bool> task = new Task<bool>(func);
          task.Start();
          if (task.Wait(5*1000))
          {
            // you got connected
          }
          else
          {
            //failed to connect
          }
    
          
          Console.ReadLine();
    
        }
      }
    }
