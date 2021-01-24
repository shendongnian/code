    var options = new ParallelOptions() { MaxDegreeOfParallelism = 2 };
    Parallel.For(0, Details.Items.Count, options, i =>
    {
        FileName = Details.Items[i].SubItems[7].Text;
        Stop.Start();
        new Methods.Generate(FileName, FileHost, Sender as BackgroundWorker);
    });
