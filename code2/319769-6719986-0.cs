                string s = @"
    [Help]
    Group0
    [Help Op]
    Group1
    [Help Mod]
    Group2
    [Help Member]
    Group3
    [Help Default]
    Group4";
                MatchCollection matches = new Regex(@"\[Help ([a-zA-Z]+)\]\s+([^[]+)\s+", RegexOptions.Singleline).Matches(s);
            
                Dictionary<string, string> result = new Dictionary<string, string>();
                foreach (Match match in matches)
                    result[match.Groups[1].Value] = match.Groups[2].Value;
                Console.WriteLine(result["Op"]);
