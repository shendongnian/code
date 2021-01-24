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
                        concurrentLogs.Enqueue(log); //repeat this log
                        sucess = false;
                    }
                }while(!sucess)
                
            });
