    public void Run()
    {
        List<string> output = new List<string>();
        for (int i = 0; i < input.Count-1; ++i)
        {
            for (int j = i+1; j< input.Count; ++j)
            {
                string leftMatch = LeftMatch(input[i], input[j]);
                if (leftMatch.Length>0 && !output.Contains(leftMatch))
                {
                    output.Add(leftMatch);
                }
            }
        }
        output.ForEach(x=>Console.WriteLine(x));
    }
    public string LeftMatch(string a, string b)
    {
        string result = "";
        for ( int i=0; i<a.Length&& i<b.Length; ++i)
        {
            if (a[i] != b[i])
            {
                if (!result.Contains(" ")) return "";
                return result.Substring(0, result.LastIndexOf(" ", StringComparison.Ordinal));
            }
            result += a[i];
        }
        return result;
    }
    List<string> input =
    new List<string>{
        "Alberry K2503 F40 D",
        "Alberry K2503 F40 S",
        "Demi Deco Denver BLK",
        "Demi Deco Denver BRN",
        "Demi Deco Tank",
        "Demi Deco Audi",
        "Samsung S 19 S10",
        "Samsung S 19 S12"
    };
