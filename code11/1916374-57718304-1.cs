    var list = new List<string>() { "E31F", "E3X", "BR39FG", "BR3X" };
    foreach(var word in list)
    {
        var match = regex.Match(word);
        if (match.Success)
        {
            var after3 = match.Groups[2].Value;
            string result = string.Empty;
            if(int.TryParse(after3,out int res))
            {
                result = match.Groups[1].Value;
                Console.WriteLine("Word: {0}, Extracted: {1}", word, result);
            }
            else
            {
                result = match.Groups[1].Value + "3";
                Console.WriteLine("Word: {0}, Extracted: {1}", word, result);
            }
        }
    }
