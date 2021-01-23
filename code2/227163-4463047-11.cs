    public void MeasurePathPerformance()
    {
        const int TestIterations = 5;
        const string Root = "C:\\";
        string seg = new string('x', 10);
        string path = null;
        Action<string, Func<double>> test = (name, action) =>
        {
            for (int i = 0; i < TestIterations; i++)
            {
                Console.WriteLine("{0}:{1:F2}ms", name, action());
            }
        };
        Console.WriteLine("***2 Args***");
        Action p2 = () => path = Path.Combine(new[] { Root, seg });
        test("params2", () => TimeTest(p2));
        Action a2 = () => path = Path.Combine(Root, seg);
        test("args2  ", () => TimeTest(a2));
        Console.WriteLine("***3 Args***");
        Action p3 = () => path = Path.Combine(new[] { Root, seg, seg });
        test("params3", () => TimeTest(p3));
        Action a3 = () => path = Path.Combine(Root, seg, seg);
        test("args3  ", () => TimeTest(a3));
        Console.WriteLine("***4 Args***");
        Action p4 = () => path = Path.Combine(new[] { Root, seg, seg, seg });
        test("params4", () => TimeTest(p4));
        Action a4 = () => path = Path.Combine(Root, seg, seg, seg);
        test("args4  ", () => TimeTest(a4));
        Console.WriteLine(path);
    }
    [SuppressMessage("Microsoft.Reliability",
        "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect")]
    private static double TimeTest(Action action)
    {
        const int Iterations = 10 * 1000 * 1000;
        Action gc = () =>
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
        };
        gc();
        action(); //JIT
        action(); //Optimize
        Stopwatch stopwatch = Stopwatch.StartNew();
        for (int j = 0; j < Iterations; j++)
        {
            action();
        }
        gc();
        double elapsed = stopwatch.Elapsed.TotalMilliseconds;
        return elapsed;
    }
