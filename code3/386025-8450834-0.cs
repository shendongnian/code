        Regex exp = new Regex(@"^(?<Name>\w+)\s*=\s*(?<Value>\d{8})\s*$", RegexOptions.Multiline);
        foreach(Match match in exp.Matches(Test))
        {
            string name = match.Groups["Name"].Value;
            string value = match.Groups["Value"].Value;
            if (value != "99999999")
            {
                Console.WriteLine("{0} = {1}", name, value);
            }
        }
    }
