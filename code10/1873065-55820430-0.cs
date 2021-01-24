    static void Do(Func<Task> a)
    {
        Console.WriteLine("Begin Do");
        await a();  //Notice we await the result here
        Console.WriteLine("End Do");
    }
