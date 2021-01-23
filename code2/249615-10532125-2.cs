    [Test]
    public void BenchmarkCompiledMethod()
    {
        Evaluator evaluator = new Evaluator(new CompilerContext(new CompilerSettings(), new ConsoleReportPrinter()));
        evaluator.InteractiveBaseClass = typeof(Variables);
        Variables.Variable1Callback = () => 5.1;
        Variables.Variable2Callback = () => 30;
        var method = evaluator.Compile("25 + Variable1 > Variable2");
        object result = null;
        method(ref result);
        Assert.AreEqual(25 + Variables.Variable1 > Variables.Variable2, result);
        Variables.Variable2Callback = () => 31;
        method(ref result);
        Assert.AreEqual(25 + Variables.Variable1 > Variables.Variable2, result);
        var sw = Stopwatch.StartNew();
        for (int i = 1; i < 10000; i++)
            method(ref result);
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
00:00:00.0003799
