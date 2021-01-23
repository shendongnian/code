    foreach(string file in  GetFiles(source))
    {
        string fileToProcess = file;
        tasks.Add(Task.Factory.StartNew(() => { ProcessCopy(fileToProcess ); }));
    }
    
    Task.WaitAll(tasks.ToArray());
