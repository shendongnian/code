    [Test]
    public void SO()
    {
        const string input = "name +value (email)";
        TestGivenMethod(input, SplitReplace, "SplitReplace");
        TestGivenMethod(input, JustSplit, "Split");
        TestGivenMethod(input, WithRegex, "Regex");
        TestGivenMethod(input, WithLinq, "WithLinq");
    }
    private void TestGivenMethod(string input, Func<string, string> method, string name)
    {
        Assert.AreEqual("email", method(input));
        var sw = Stopwatch.StartNew();
        string res = "";
        for (int i = 0; i < 1000000; i++)
        {
            var email = method(input);
            res = email;
        }
        sw.Stop();
        Assert.AreEqual("email", res);
        Console.WriteLine("{1} takes {0} ticks per call", sw.ElapsedTicks/1000000.0, name);
    }
    string SplitReplace(string val)
    {
        string[] parts = val.Split('(');
        return parts[1].Replace(")", String.Empty);
    }
    string JustSplit(string val)
    {
        string[] parts = val.Split('(', ')');
        return parts[1];
    }
    private static Regex method3Regex = new Regex(@"\(([\w@]+)\)");
    string WithRegex(string val)
    {
        return method3Regex.Match(val).Groups[1].Value;
    }
    string WithLinq(string val)
    {
        return new string(val.SkipWhile(c => c != '(').Skip(1).TakeWhile(c => c != ')').ToArray());
    }
