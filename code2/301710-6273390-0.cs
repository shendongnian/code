    static void Main()
    {
      Regex r = new Regex(@"<a href=""[^""]+"">([^<]+)");
      string s0 = @"<p><a href=""docs/123.pdf"">33</a></p>";
      string s1 = r.Replace(s0, m => GetNewLink(m));
      Console.WriteLine(s1);
    }
    static string GetNewLink(Match m)
    {
      return string.Format(@"(<a href=""{0}.html"">{0}", m.Groups[1]);
    }
