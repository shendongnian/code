    using System.IO;
    using System;
     
    using System.Threading.Tasks;
    class Input
    {
        public Input()
        {
    
        }
    
        public void   hello()
        {
            Console.WriteLine("some task");
               Task.Delay(1000).Wait();
            Console.WriteLine("after some time");
          
        }
    
     
    }
    
    class SomeExample
    {
        public static void Main(string[] args)
        {
            Input std1 = new Input();
            std1.hello() ;
      
        }
    }
