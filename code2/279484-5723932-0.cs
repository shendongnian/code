            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                bool flag = true;
    
                while (flag == true)
                {
                    stopWatch.Stop();
                    Console.Write(stopWatch.ElapsedMilliseconds + "ms");
                    Console.Write('\r');
                    stopWatch.Start();
                    //HERE IS MY PROCESS
    
                    //flag = false;
    
                }
    
                stopWatch.Stop();
            }
