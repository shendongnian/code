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
                WorkerClass workerClass = new WorkerClass(message);
    
                ThreadStart newThread = new ThreadStart(workerClass.DoWork);
    
                Thread myThread = new Thread(newThread);
                myThread.Start();
                Console.Read();
    
            }
    
           
        }
    
        internal class WorkerClass
        {
            private string _workerVariable = "";
    
            internal WorkerClass(string workerVariable)
            {
                _workerVariable = workerVariable;
            }
    
            internal void DoWork()
            {
                Console.WriteLine(_workerVariable);
            }
        }
    
    }
