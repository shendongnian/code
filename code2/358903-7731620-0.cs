    protected string ObfuscateUsingMatchEvaluator(string input)
    {
                var re = new Regex(@"<a href=""mailto:[a-zA-Z0-9\.,|\-|_@?= &]*"">",            RegexOptions.IgnoreCase | RegexOptions.Multiline);
                return re.Replace(input, DoObfuscation);
    
    }
    protected string DoObfuscation(Match match)
    {
           return obfusucateEmail(match.Value);
    }
