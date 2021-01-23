    private static void SpeedTest()
    {
        const int loop = 100000;
        string first = "a bc d";
        string second = "ABC D";
        var compChar = new StringCompIgnoreWhiteSpace();
        Stopwatch sw1 = Stopwatch.StartNew();
        for (int i = 0; i < loop; i++)
        {
            bool equals = compChar.Equals(first, second);
        }
        sw1.Stop();
        Console.WriteLine(string.Format("char time =  {0}", sw1.Elapsed)); //char time =  00:00:00.0361159
        var compRegex = new StringCompIgnoreWhiteSpaceRegex();
        Stopwatch sw2 = Stopwatch.StartNew();
        for (int i = 0; i < loop; i++)
        {
            bool equals = compRegex.Equals(first, second);
        }
        sw2.Stop();
        Console.WriteLine(string.Format("regex time = {0}", sw2.Elapsed)); //regex time = 00:00:00.2773072
    }
    private class StringCompIgnoreWhiteSpaceRegex : IEqualityComparer<string>
    {
        public bool Equals(string strx, string stry)
        {
            if (strx == null)
                return string.IsNullOrWhiteSpace(stry);
            else if (stry == null)
                return string.IsNullOrWhiteSpace(strx);
            string a = System.Text.RegularExpressions.Regex.Replace(strx, @"\s", "");
            string b = System.Text.RegularExpressions.Regex.Replace(stry, @"\s", "");
            return String.Compare(a, b, true) == 0;
        }
        public int GetHashCode(string obj)
        {
            if (obj == null)
                return 0;
            string a = System.Text.RegularExpressions.Regex.Replace(obj, @"\s", "");
            return a.GetHashCode();
        }
    }
