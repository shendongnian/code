    var progress = new Progress<double>(); // Progress captures the System.Threading.SynchronizationContext at construction.
    progress.ProgressChanged += (object sender, double e) =>
    {
        Console.WriteLine($"Progress: {e:0%}");
    };
    var numbers = Enumerable.Range(1, 10);
    var sum = numbers
    .AsParallel()
    .WithDegreeOfParallelism(3)
    .Select(n => { Thread.Sleep(500); return n; }) // Pretend we are doing something heavy
    .WithProgressReporting(10, progress) // <--- the extension method
    .Sum();
    Console.WriteLine($"Sum: {sum}");
