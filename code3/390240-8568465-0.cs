    private static void Main()
    {
        Regex pattern = new Regex(@"(?<Name>[\w\-_]+)\.+(?<Value>[\w\-_]+)");
        string sample = @"(123456789..value > 2000) && (987654321.Value < 12)";
        string result = pattern.Replace(sample,
                                        m =>
                                        String.Format(
                                            "ClassName.GetInfo(\"{0}\").Get{1}{2}()",
                                            m.Groups["Name"].Value,
                                            Char.ToUpper(m.Groups["Value"].Value[0]),
                                            m.Groups["Value"].Value.Substring(1))
            );
        Console.WriteLine(result);
    }
