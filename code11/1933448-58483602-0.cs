c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeMethod1();
            ExecuteParallelAsync();
            SomeMethod2();
            Console.ReadKey();
        }
        static void SomeMethod1()
        {
            Console.WriteLine("SomeMethod1");
        }
        static void SomeMethod2()
        {
            Console.WriteLine("SomeMethod2");
        }
        static void ExecuteParallelAsync()
        {
            Console.WriteLine("\tstart of ExecuteParallelAsync");
            var rd = new Random();
            
            List<Action> methods = new List<Action>()
            {
                ()=>{Thread.Sleep((int) Math.Ceiling(rd.NextDouble()*1000));Console.WriteLine("MyMethod1"); },
                ()=>{Thread.Sleep((int) Math.Ceiling(rd.NextDouble()*1000));Console.WriteLine("MyMethod2"); },
                ()=>{Thread.Sleep((int) Math.Ceiling(rd.NextDouble()*1000));Console.WriteLine("MyMethod3"); },
            };
            Task.WaitAll(methods.Select((action) => Task.Run(action)).ToArray());
            Console.WriteLine("\tend of ExecuteParallelAsync");
        }
    }
}
***example of a result:***
SomeMethod1
        start of ExecuteParallelAsync
MyMethod2
MyMethod3
MyMethod1
        end of ExecuteParallelAsync
SomeMethod2
