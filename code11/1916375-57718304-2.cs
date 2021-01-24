    var list = new List<string>() { "E31F", "E3X", "BR39FG", "BR3X" };
    foreach (var word in list)
    {
        var match = regex.Match(word);
        if (match.Success)
        {
            var after3 = match.Groups[2].Value;
            string result = string.Empty;
            if (int.TryParse(after3, out int res))
            {
                result = match.Groups[1].Value;
            }
            else
            {
                result = match.Groups[1].Value + "3";
            }
            Console.WriteLine("{0} ==> {1}", word, result);
        }
    }
