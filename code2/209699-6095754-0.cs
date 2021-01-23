    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace AsyncText
    {
        class Program
        {
            static void Main(string[] args)
            {
                Derived d = new Derived();
    
                TaskEx.Run(() => d.DoStuff()).Wait();
    
                System.Console.Read();
            }
            public class Base
            {
    	        protected string SomeData { get; set; }
    
                protected async Task DeferProcessing()
                {
    		        await TaskEx.Run(() => Thread.Sleep(1) );
                    return;
    	        }
    	        public async virtual Task DoStuff() {
    		        Console.WriteLine("Begin Base");
    		        Console.WriteLine(SomeData);
    		        await DeferProcessing();
    		        Console.WriteLine("End Base");
    		        Console.WriteLine(SomeData);
    	        }
            }
            public class Derived : Base
            {
                public async override Task DoStuff()
    	        {
    		        Console.WriteLine("Begin Derived");
    		        SomeData = "Hello";
    		        var x = base.DoStuff();
    		        SomeData = "World";
    		        Console.WriteLine("Mid 1 Derived");
    		        await x;
    		        Console.WriteLine("EndDerived");
    	        }
            }
        }
    }
