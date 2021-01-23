    MatchCollection uppercase = Regex.Matches(s, @"\p{Lu}");
    MatchCollection lowercase = Regex.Matches(s, @"\p{Ll}");
    MatchCollection digits = Regex.Matches(s, @"\p{N}");
    MatchCollection nonAlpha = Regex.Matches(s, @"[\p{N}\p{L}]");
    Console.WriteLine("Upper: " + uppercase.Count);
    Console.WriteLine("Lower: " + lowercase.Count);
    Console.WriteLine("Digits: " + digits.Count);
    Console.WriteLine("NonAlpha: " + nonAlpha.Count);
