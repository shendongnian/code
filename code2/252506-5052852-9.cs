      ServicePointManager.DefaultConnectionLimit = 20;//Please test different numbers here
      var tasks = new List<Task<string>>();
      for (int i = 1990; i < 2090; i++)
      {
        var postParameters = new NameValueCollection();
        postParameters.Add("data", i.ToString());
        tasks.Add(Task.Factory.StartNew(() => { return GetWebResponse("http://www.abc123.com", postParameters); }));
      }
      Task.WaitAll(tasks.ToArray());
      //At this point tasks[0].Result will be the result (The Response) of the first task
      //tasks[1].Result will be the result of the second task and so on.
