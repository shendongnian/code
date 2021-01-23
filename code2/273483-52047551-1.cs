            using System;
            using System.Diagnostics;
                //Setting a Stopwatch 
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < length; i++)
                {
                    //some logic there
                }
                //Stopping a Stopwatch
                sw.Stop();
                Console.WriteLine(sw.Elapsed);
                
                //delay
                Console.ReadLine();
