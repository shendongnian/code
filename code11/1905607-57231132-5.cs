    public static async Task MainAsync()
            {
                var task0 = Task.Run(WorkWithSleep("task0",5000));
                var task2 = Task.Run(WorkWithSleep("task2"));
    
                var task0or2 = await Task.WhenAny(task0, task2);
    
                if (task0or2 == task0)
                {
                    WorkWithSleep("task1")(); //No need to do a run since the thred we are on in not buisy. and can just run on the same one
                    await task2;
                    WorkWithSleep("task3")();
                }
                else
                {
                    WorkWithSleep("task3")();
                    await task0;
                    WorkWithSleep("task1")();
                }
            }
