    System.Collections.Generic.List<System.Threading.Tasks.Task> tasks = new System.Collections.Generic.List<System.Threading.Tasks.Task>();
    for (int i = 0; i < 20; i++)
    {
      tasks.Add(System.Threading.Tasks.Task.Run(() => ApiRef1(i, log));
    }
    await System.Threading.Tasks.Task.WhenAll(tasks);
