    Regex regex = new Regex("(?<First>[,\"]url=)(?<Url>[^\\?]*\\?itag=(?<iTag>[0-9]*))(?<Last>\\u0026)");
    string input = ",url=http://domain.com?itag=25\u0026,url=http://hello.com?itag=11\u0026";
    
    foreach(Match match in regex.Matches(input))
    {
        System.Console.WriteLine("1. "+match);
        System.Console.WriteLine("  1. "+match.Groups["First"]);
        System.Console.WriteLine("  2. "+match.Groups["Url"]);
        System.Console.WriteLine("  3. "+match.Groups["iTag"]);
        System.Console.WriteLine("  4. "+match.Groups["Last"]);
    }
