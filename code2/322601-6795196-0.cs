    void DoWork(object sender, DoWorkEventArgs arg)
    {
       List<string> results = new List<string>();
       results.Add("one");
       results.Add("two");
       results.Add("three");
       arg.Results = results;
    }
    
    void WorkComplete(object sender, runWorkerCompelteEventArgs arg)
    {
       //Get our result back as a list of strings
       List<string> results = (List<string>)arg.Result;
       PrintResults(results);
    }
