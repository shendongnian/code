    Dictionary<string, dynamic> compute = new Dictionary<string, dynamic>();
    compute.Add("Vessel_Weight", 123);
    compute.Add("Cargo_Weight", 24);
    compute.Add("Cargo_Tariff", 9);
    
        string rule = "result=(Vessel_Weight>200)
            ?(Cargo_Weight*Cargo_Tariff*2)
            :(Cargo_Weight*Cargo_Tariff)";
        
        string process = rule.Replace(" ", "");
        foreach (Match level1 in Regex.Matches(process, "\\([^\\)]+\\)"))
        {
            string parenthesis = level1.Value;
            string keepit = parenthesis;
            Console.Write("{0} -> ", parenthesis);
            // replace all named variable with values from the dictionary
            foreach (Match level2 in Regex.Matches(parenthesis, "[a-zA-z0-9_]+"))
            {
                string variable = level2.Value;
                if (Regex.IsMatch(variable, "[a-zA-z_]+"))
                {
                    if (!compute.ContainsKey(variable))
                        throw new Exception("Variable not found");
                    parenthesis = parenthesis.Replace(variable, compute[variable].ToString());
                }
            }
            parenthesis = parenthesis.Replace("(", "").Replace(")", "");
            Console.Write("{0} -> ", parenthesis);
            // do the math
            List<double> d = new List<double>();
            foreach (Match level3 in Regex.Matches(parenthesis, "[0-9]+(\\.[0-9]+)?"))
            {
                d.Add(double.Parse(level3.Value));
                parenthesis = Regex.Replace(parenthesis, level3.Value, "");
            }
            double start = d[0];
            for (var i = 1; i < d.Count; i++)
            {
                switch (parenthesis[i - 1])
                {
                    case '+':
                        start += d[i];
                        break;
                    case '-':
                        start -= d[i];
                        break;
                    case '*':
                        start *= d[i];
                        break;
                    case '/':
                        start /= d[i];
                        break;
                    case '=':
                        start = (start == d[i]) ? 0 : 1;
                        break;
                    case '>':
                        start = (start > d[i]) ? 0 : 1;
                        break;
                    case '<':
                        start = (start < d[i]) ? 0 : 1;
                        break;
                }
            }
            parenthesis = start.ToString();
            Console.WriteLine(parenthesis);
            rule = rule.Replace(keepit, parenthesis);
        }
        Console.WriteLine(rule);
        // peek a value in case of a condition
        string condition = "[0-9]+(\\.[0-9]+)?\\?[0-9]+(\\.[0-9]+)?:[0-9]+(\\.[0-9]+)?";
        if (Regex.IsMatch(rule, condition))
        {
            MatchCollection m = Regex.Matches(rule, "[0-9]+(\\.[0-9]+)?");
            int check = int.Parse(m[0].Value) + 1;
            rule = rule.Replace(Regex.Match(rule, condition).Value, m[check].Value);
        }
        Console.WriteLine(rule);
        // final touch
        int equal = rule.IndexOf("=");
        compute.Add(rule.Substring(0, equal - 1), double.Parse(rule.Substring(equal + 1)));
