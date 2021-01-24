    string input = string.Empty;
    var task = Task.Run(() => input = Console.ReadLine());
    if(task.Wait(TimeSpan.FromSeconds(5)))
    {
    	Console.WriteLine($"Value Read {input}");
    }
    else
    {
    	Console.WriteLine("You are timed out");
    }
