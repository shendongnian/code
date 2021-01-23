    for (int ii = 0; ii <= 4; ii++)
    {
        var wreq = (HttpWebRequest)WebRequest.Create("..." + ii);
    
        var taskResp = Task.Factory.FromAsync<WebResponse>(wreq.BeginGetResponse, 
                                                        wreq.EndGetResponse, 
                                                        null);
        taskResp.ContinueWith(tsk => new StreamReader(tsk.Result.GetResponseStream()).ReadToEnd().Trim())
                .ContinueWith((Task<string> trs) => 
                    { 
                        var result = trs.Result;
                        DoSomthingWithTheResult(result);
                    });
    }
