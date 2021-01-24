        string s1 = "cos555cos";
        string s2 = "coscos1";
        string s3 = "22coscos";
        string s4 = "333coscos";
        string s5 = "cosco444s";
        IList<string> test = new List<string>();
        test.Add(s1);
        test.Add(s2);
        test.Add(s3);
        test.Add(s4);
        test.Add(s5);
        var orderedEnumerable = test.OrderBy(StripNumeric);
        foreach (string s in orderedEnumerable)
        {
            Console.WriteLine(s);
        }
        int StripNumeric(string input)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return int.Parse(digitsOnly.Replace(input, ""));
        }
