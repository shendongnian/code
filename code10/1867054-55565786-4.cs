    // this will enumerate and start the tasks
    var tasks = Enumerable.Range(1, 10)
                          .Select(n => Task.Run(() => Console.WriteLine(n)))
                          .ToList();
    // wait for them all to finish
    Task.WaitAll(tasks.ToArray());
    Console.WriteLine(String.Join(", ", tasks.Select(t => t.Id)));
