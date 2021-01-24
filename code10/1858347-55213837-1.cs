    public async Task DoSomething()
    {
       var newload = new GenericLoad();
    
       var task1 = Task.Run(() => newload.Parse(CSVFile1, ','));
       var task2 = Task.Run(() => newload.Parse(CSVFile2, '|'));
    
       await Task.WhenAll(task1, task2);
    
       PrintCSV(task1.Result);
       PrintCSV(task2.Result);
    
    }
