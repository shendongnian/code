    public void Test()
    {
        System.Text.RegularExpressions.Regex rx = new Regex(@"(?<prefix>.*\-)(?<digit>\d+)");
        string input = "BA-0001-3";
        string output = string.Empty;
        int digit = 0;
        if (int.TryParse(rx.Replace(input, "${digit}"), out digit))
        {
            output = rx.Replace(input, "${prefix}" + (digit + 1));
        }
        Console.WriteLine(output);
    }
