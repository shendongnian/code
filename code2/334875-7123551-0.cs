    static void Main(string[] args)
    {
        var worker = new BackgroundWorker();
            
        worker.DoWork += (sender, e) => { throw new ArgumentException(); };
        worker.RunWorkerCompleted += (sender, e) => Console.WriteLine(e.Error.Message);
        worker.RunWorkerAsync();
        Console.ReadKey();
    }
