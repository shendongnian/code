    var runningTasks = new List<Task<string>>();
    
    for (int ii = 0; ii <= 4; ii++)
    {
        var wreq = (HttpWebRequest)WebRequest.Create("..." + ii);
    
        var taskResp = Task.Factory.FromAsync<WebResponse>(wreq.BeginGetResponse, 
                                                        wreq.EndGetResponse, 
                                                        null);
        var taskResult = taskResp.ContinueWith(tsk => new StreamReader(tsk.Result.GetResponseStream()).ReadToEnd().Trim());
        runningTasks.Add(taskResult);
    }
    
    Task.WaitAll(runningTasks.ToArray());
    IEnumerable<string> results = runningTasks.Select(tsk => tsk.Result);
