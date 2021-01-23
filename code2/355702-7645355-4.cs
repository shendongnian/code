    using System;
    using System.IO;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Worker.Start();
                Thread.Sleep(2000);
            }
    
            public static class Worker
            {
                private static Timer timer;
    
                public static void Start()
                {
                    //Work(new object());
                    int period = 1000;
                    timer = new Timer(new TimerCallback(Work), null, period, period);
                }
    
                public static void Work(object stateInfo)
                {
                    TextWriter tw = new StreamWriter(@"w:\date.txt");
    
                    // write a line of text to the file
                    tw.WriteLine(DateTime.Now);
    
                    // close the stream
                    tw.Close();
                }
    
            }
        }
    }
