    [TestMethod]
    public async Task SimpleTest()
    {
        bool isOK = false;
        Func<Task> asyncMethod = async () =>
        {
            Console.WriteLine("Task.BeforeDelay");
            await Task.Delay(1000);
            Console.WriteLine("Task.AfterDelay");
            isOK = true;
            Console.WriteLine("Task.Ended");
        };
        Console.WriteLine("Main.BeforeStart");
        Task myTask = asyncMethod();
        Console.WriteLine("Main.AfterStart");
        await myTask;
        Console.WriteLine("Main.AfterAwait");
        Assert.IsTrue(isOK, "OK");
    }
