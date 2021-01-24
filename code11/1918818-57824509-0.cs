    private static double Parse(string ParseEquation)
    {
        string[] split = Regex.Split(ParseEquation, @"(?<=[+-/*])");
        List<string> keywords = new List<string>();
        foreach (string i in split)
        {
            var var1 = Regex.Match(i, @"\d+").Value;
            keywords.Add(var1);
            var var2 = Regex.Match(i, @"([+-/*])").Value;
            keywords.Add(var2);
        }
        double sum = double.Parse(keywords[0]);
        for (int i = 2; i < keywords.Count - 1; i += 2)
        {
            string keyword = keywords[i - 1];
            if (keyword == "+")
                sum = Addition(sum, double.Parse(keywords[i]));
            else if (keyword == "-")
                sum = Subtraction(sum, double.Parse(keywords[i]));
            else if (keyword == "/")
                sum = Division(sum, double.Parse(keywords[i]));
            else if (keyword == "*")
                sum = Multiplication(sum, double.Parse(keywords[i]));
        }
        return sum;
    }
