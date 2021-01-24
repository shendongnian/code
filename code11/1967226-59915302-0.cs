    static string ExtractEmails(string data)
    {
        //instantiate with this pattern 
        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);
        //find items that matches with our pattern
        MatchCollection emailMatches = emailRegex.Matches(data);
        //StringBuilder sb = new StringBuilder();
        string s = "";
        foreach (Match emailMatch in emailMatches)
        {
            //sb.AppendLine(emailMatch.Value);
            s += emailMatch.Value + ",";
        }
        return s;
    }
    static readonly List<ParsResult> _results = new List<ParsResult>();
    static Int32 _maxDepth = 4;
    static List<string> urlsAlreadyVisited = new List<string>();
    static String Foo(String urlToCheck = null, Int32 depth = 0, ParsResult parent = null)
    {
        if (urlsAlreadyVisited.Contains(urlToCheck))
            return string.Empty;
        else
            urlsAlreadyVisited.Add(urlToCheck);
        string email = "";
        if (depth >= _maxDepth) return email;
        String html;
        using (var wc = new WebClient())
            html = wc.DownloadString(urlToCheck ?? parent.Url);
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        var aNods = doc.DocumentNode.SelectNodes("//a");
        if (aNods == null || !aNods.Any()) return email;
        // Get Distinct URLs from all the URls on this page.
        List<string> allUrls = aNods.ToList().Select(x => x.Attributes["href"].Value).Where(url => url.StartsWith("http")).Distinct().ToList();
        
        foreach (string url in allUrls)
        {
            var wc2 = new WebClient();
            try
            {
                email += ExtractEmails(wc2.DownloadString(url));
            }
            catch { /* Swallow Exception ... URL not found or other errors. */ continue; }
            Console.WriteLine(email);
            var result = new ParsResult
            {
                Depth = depth,
                Parent = parent,
                Url = url
            };
            _results.Add(result);
            Console.WriteLine("{0} - {1}", depth, result.Url);
            email += Foo(depth: depth + 1, parent: result);
        }
        return email;
    }
    public class ParsResult
    {
        public int Depth { get; set; }
        public ParsResult Parent { get; set; }
        public string Url { get; set; }
    }
    // ========== MAIN CLASS ==========
    static void Main(string[] args)
    {
        String res = Foo("http://www.mobileridoda.com", 0);
        Console.WriteLine("emails " + res);
    }
