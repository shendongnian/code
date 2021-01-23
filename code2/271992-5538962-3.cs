    static void RunTasks()
    {
        Task1();
        Task2();
        Task3();
    }
    
    static void Main()
    {
       new Thread(RunTasks).Start();
    }
