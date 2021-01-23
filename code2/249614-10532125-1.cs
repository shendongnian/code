    [Test]
    public void BenchmarkEvaluate()
    {
        Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
        evaluator.InteractiveBaseClass = typeof(Variables);
        Variables.Variable1Callback = () => 5.1;
        Variables.Variable2Callback = () => 30;
        var sw = Stopwatch.StartNew();
        for (int i = 1; i < 10000; i++)
            evaluator.Evaluate("25 + Variable1 > Variable2");
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
00:00:07.6035024
