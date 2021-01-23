    public static void Performance(Action fn)
    {
        var timer = new Stopwatch();
        timer.Start();
    
        for (var i = 0; i < 10000000; ++i)
        {
            fn();
        }
    
        timer.Stop();
    
        Console.WriteLine("{0} Time: {1}ms ({2})", fn.ToString(), timer.ElapsedMilliseconds, timer.ElapsedTicks);
    }
    
    static void Main(string[] args)
    {
        var stringList = new List<string>() {
            "123123123213",
            "1232113213213",
            "123213123"
        };
    
        string outcome = String.Empty;
        Performance(() =>
        {
            outcome = string.Join(",", stringList);
        });
    
        Console.WriteLine(outcome);
    
        Performance(() =>
        {
            StringBuilder builder = new StringBuilder();
            stringList.ForEach
                (
                    val =>
                    {
                        builder.Append(val);
                        builder.Append(",");
                    }
                );
            outcome = builder.ToString();
            outcome = outcome.Substring(0, outcome.Length - 1);
        });
    
        Console.WriteLine(outcome);
    
        Console.ReadKey();
    
    }
