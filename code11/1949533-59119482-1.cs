                Parallel.ForEach(concurrentLogs, parallelOptions, log => { 
                bool sucess = true;
                do
                {
                    try
                    {
                        //Do work
                        Console.WriteLine(log);
                    }
                    catch (Exception ex)
                    {
                        sucess = false;
                    }
                }while(!sucess)
                
            });
