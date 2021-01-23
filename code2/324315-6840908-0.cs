    var task = Task<int>.Factory.StartNew(() => GenerateResult());
    task.ContinueWith(t =>
    {
        Console.WriteLine(t.Result);
    });
