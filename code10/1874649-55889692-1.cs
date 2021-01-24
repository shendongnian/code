    var tPass1 = Task.FromResult(1);
    var tFail1 = Task.FromException<int>(new ArgumentException("fail1"));
    var tFail2 = Task.FromException<int>(new ArgumentException("fail2"));
    var task = WhenAllEx(tPass1, tFail1, tFail2);
    task.Wait();
    Console.WriteLine($"Status: {task.Status}");
    Console.WriteLine($"Results: {String.Join(", ", task.Result.Results)}");
    Console.WriteLine($"Exceptions: {String.Join(", ", task.Result.Exceptions.Select(ex => ex.Message))}");
