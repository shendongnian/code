    static void Main(string[] args)
    {
       Task callTask = Task.Run(() => Run());
       callTask.Wait();
    }
    public async void Run()
    {
        await DoSomeStuffAsync();
    }
