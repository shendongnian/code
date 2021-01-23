    using System;  
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using System.Threading; 
     
    namespace ConsoleApplication1 
    { 
      class Program 
      { 
        static void Main(string[] args) 
        { 
            Console.WriteLine("Taking data from Main Thread\n->"); 
            string message = Console.ReadLine(); 
     
            //Put something into the CallContext
            CallContext.SetData("time", DateTime.Now);
            ThreadStart newThread = new ThreadStart(delegate { Write(message); }); 
     
            Thread myThread = new Thread(newThread); 
     
        } 
     
        public static void Write(string msg) 
        { 
            Console.WriteLine(msg); 
            //Get it back out of the CallContext
            Console.WriteLine(CallContext.GetData("time"));
            Console.Read(); 
        } 
      } 
    } 
