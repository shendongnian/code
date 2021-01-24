     try
                {
                    Task task1 = Task.Run(() => Method1());
                    Task task2 = Task.Run(() => Method2());
                    Task task3 = Task.Run(() => Method3());
                    Task.WaitAny(task1, task2, task3);
    
                }
                catch (System.Exception)
                {    
                    throw;
                }
