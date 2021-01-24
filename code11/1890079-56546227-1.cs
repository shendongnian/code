     public static async Task<string> ShortTask()
     {
         await Task.Delay(500);
         return "ShortFoo";
     }
     public static async Task<string> LongTask()
     {
         await Task.Delay(5000);
         return "LongFoo";
     }
    var sw = new Stopwatch();
    sw.Start();
    var result1 = await OnlyWaitFor(ShortTask(), TimeSpan.FromSeconds(1));
    sw.Stop();
    Console.WriteLine($"Got back '{result1}' in {sw.ElapsedMilliseconds}ms");
    sw.Reset();
    sw.Start();
    var result2 = await OnlyWaitFor(LongTask(), TimeSpan.FromSeconds(1));
    sw.Stop();
    Console.WriteLine($"Got back '{result2}' in {sw.ElapsedMilliseconds}ms");
