    Task<string> dataTask = DependencyService.Get<INetworkUtility>().GetData();
    await Task.WhenAny(dataTask, Task.Delay(10000)); // 10.000ms timeout
    if(dataTask.IsCompletedSuccessfully) {
        //all good:
        string dataString = dataTask.Result;
    }else{
        //we hit the time limit
    }
