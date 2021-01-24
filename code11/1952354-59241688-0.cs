        Console.WriteLine("Starting Process {0}", i);
        tasks.Add(DoWorkAsync(i));
    }
    foreach (var task in await Task.WhenAll(tasks))
    {
        if (task.Item2)
        {
            Console.WriteLine("Ending Process {0}", task.Item1);
        }
    }
`
