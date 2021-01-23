    class TagMatch
    {
        public string Tag { get; set; }
        public Capture Capture { get; set; }
        public readonly List<string> Substrings = new List<string>();
    }
    static void Main(string[] args)
    {
        var rx = new Regex(@"(?<OPEN>\[[A-Za-z]+?\])|(?<CLOSE>\[/[A-Za-z]+?\])|(?<TEXT>[^\[]+|\[)");
        var str = "Lorem [AA]ipsum [BB]dolor sit [/BB]amet, [ consectetur ][/AA]adipisici elit, sed eiusmod tempor incidunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquid ex ea commodi consequat. Quis aute iure reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint obcaecat cupiditat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        var matches = rx.Matches(str);
        var recurse = new Stack<TagMatch>();
        recurse.Push(new TagMatch { Tag = String.Empty });
        foreach (Match match in matches)
        {
            var text = match.Groups["TEXT"];
            TagMatch last;
            if (text.Success)
            {
                last = recurse.Peek();
                last.Substrings.Add(text.Value);
                continue;
            }
            var open = match.Groups["OPEN"];
            string tag;
            if (open.Success)
            {
                tag = open.Value.Substring(1, open.Value.Length - 2);
                recurse.Push(new TagMatch { Tag = tag, Capture = open.Captures[0] });
                continue;
            }
            var close = match.Groups["CLOSE"];
            tag = close.Value.Substring(2, close.Value.Length - 3);
            last = recurse.Peek();
            if (last.Tag == tag)
            {
                recurse.Pop();
                var lastLast = recurse.Peek();
                lastLast.Substrings.Add("**" + last.Tag + "**");
                lastLast.Substrings.AddRange(last.Substrings);
                lastLast.Substrings.Add("**/" + last.Tag + "**");
            }
            else
            {
                throw new Exception();
            }
        }
        if (recurse.Count != 1)
        {
            throw new Exception();
        }
        var sb = new StringBuilder();
        foreach (var str2 in recurse.Pop().Substrings)
        {
            sb.Append(str2);
        }
        var str3 = sb.ToString();
    }
