    string text = "One word, duel. Limes said bye.";
    string pattern = @"\b(?<w>\p{L}+)(?:\P{L}+(?<w>(\p{L})(?<=\1\P{L}+\1)\p{L}*))+\b";
    Match result = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
    List<string> output = new List<string>();
    if (result.Success) 
    {
    	foreach (Capture c in result.Groups["w"].Captures)
    		output.Add(c.Value);
    }
    Console.WriteLine(string.Join(", ", output));
