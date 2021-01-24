    var tasks = Enumerable.Range(1, 10)
                          .Select(n => Task.Run(() => Console.WriteLine(n)))
                          .ToList();
    Task.WaitAll(tasks.ToArray());
    Console.WriteLine(String.Join(", ", tasks.Select(t => t.Id)));
