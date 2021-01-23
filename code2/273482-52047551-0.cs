            using System;
            using System.Diagnostics;
    
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < length; i++)
                {
                    //some logic there
                }
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
                
                //delay
                Console.ReadLine();
