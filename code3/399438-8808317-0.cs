    var worker = new BackgroundWorker();
    worker.DoWork += (obj, args) =>
    {
        args.Result = myList.Select(TimeConsumingTask).ToList();
    };
    worker.RunWorkerCompleted += (obj, args) =>
    {
        var result = (IList<string>)args.Result;
        foreach(string value in result)
        {
            listBox.Add(result);
        }
    }; 
    worker.RunWorkerAsync();
