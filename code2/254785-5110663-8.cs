    // Some classes
    class BaseTagMatch {
        public Capture Capture;
        public override string ToString()
        {
            return String.Format("{1}: {2} [{0}]", GetType(), Capture.Index, Capture.Value.ToString());
        }
    }
    class BeginTag : BaseTagMatch
    {
        public int Index;
        public Capture Options;
        public EndTag EndTag;
    }
    class EndTag : BaseTagMatch {
        public int Index;
        public BeginTag BeginTag;
    }
    class Text : BaseTagMatch
    {
    }
    class UnmatchedTag : BaseTagMatch
    {
    }
    // The code
    var pattern =
        @"(?# line 01) ^" +
        @"(?# line 02) (" +
        // Non [ Text
        @"(?# line 03)   (?>(?<TEXT>[^\[]+))" +
        @"(?# line 04)   |" +
        // Immediately closed tag [a/]
        @"(?# line 05)   (?>\[  (?<TAG>  [A-Z]+  )  \x20*  =?  \x20*  (?<TAG_OPTION>(  (?<=  =  \x20*)  (  (?!  \x20*  /\])  [^\[\]\r\n]  )*  )?  )  (?<BEGIN_INNER_TEXT>)(?<END_INNER_TEXT>)  \x20*  /\]  )" +
        @"(?# line 06)   |" +
        // Matched open tag [a]
        @"(?# line 07)   \[  (?<TAG>  (?<OPEN>  [A-Z]+  )  )  \x20* =?  \x20* (?<TAG_OPTION>(  (?<=  =  \x20*)  (  (?!  \x20*  \])  [^\[\]\r\n]  )*  )?  )  \x20*  \]  (?<BEGIN_INNER_TEXT>)" +
        @"(?# line 08)   |" +
        // Matched close tag [/a]
        @"(?# line 09)   (?>(?<END_INNER_TEXT>)  \[/  \k<OPEN>  \x20*  \]  (?<-OPEN>))" +
        @"(?# line 10)   |" +
        // Unmatched open tag [a]
        @"(?# line 11)   (?>(?<UNMATCHED_TAG>  \[  [A-Z]+  \x20* =?  \x20* (  (?<=  =  \x20*)  (  (?!  \x20*  \])  [^\[\]\r\n]  )*  )?  \x20*  \]  )  )" +
        @"(?# line 12)   |" +
        // Unmatched close tag [/a]
        @"(?# line 13)   (?>(?<UNMATCHED_TAG>  \[/  [A-Z]+  \x20*  \]  )  )" +
        @"(?# line 14)   |" +
        // Single [ of Text (unmatched by other patterns)
        @"(?# line 15)   (?>(?<TEXT>\[))" +
        @"(?# line 16) )*" +
        @"(?# line 17) (?(OPEN)(?!))" +
        @"(?# line 18) $";
    var rx = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);
    var match = rx.Match("[div=c:max max]asdf[p = 1   ] a [p=2] [b  =  p/pp   /] [q/] \n[a]sd [/z]  [ [/p]f[/p]asdffds[/DIV] [p][/p]");
    ////var tags = match.Groups["TAG"].Captures.OfType<Capture>().ToArray();
    ////var tagoptions = match.Groups["TAG_OPTION"].Captures.OfType<Capture>().ToArray();
    ////var begininnertext = match.Groups["BEGIN_INNER_TEXT"].Captures.OfType<Capture>().ToArray();
    ////var endinnertext = match.Groups["END_INNER_TEXT"].Captures.OfType<Capture>().ToArray();
    ////var text = match.Groups["TEXT"].Captures.OfType<Capture>().ToArray();
    ////var unmatchedtag = match.Groups["UNMATCHED_TAG"].Captures.OfType<Capture>().ToArray();
    var tags = match.Groups["TAG"].Captures.OfType<Capture>().Select((p, ix) => new BeginTag { Capture = p, Index = ix, Options = match.Groups["TAG_OPTION"].Captures[ix] }).ToList();
    Func<Capture, int, EndTag> func = (p, ix) =>
    {
        var temp = new EndTag { Capture = p, Index = ix, BeginTag = tags[ix] };
        tags[ix].EndTag = temp;
        return temp;
    };
    var endTags = match.Groups["END_INNER_TEXT"].Captures.OfType<Capture>().Select((p, ix) => func(p, ix));
    var text = match.Groups["TEXT"].Captures.OfType<Capture>().Select((p, ix) => new Text { Capture = p });
    var unmatchedTags = match.Groups["UNMATCHED_TAG"].Captures.OfType<Capture>().Select((p, ix) => new UnmatchedTag { Capture = p });
    // Here you have all the tags and the inner text neatly ordered and ready to be recomposed in a StringBuilder.
    var allTags = tags.Cast<BaseTagMatch>().Union(endTags).Union(text).Union(unmatchedTags).ToList();
    allTags.Sort((p, q) => p.Capture.Index - q.Capture.Index);
    foreach (var el in allTags)
    {
        var type = el.GetType();
        if (type == typeof(BeginTag))
        {
        }
        else if (type == typeof(EndTag))
        {
        }
        else if (type == typeof(UnmatchedTag))
        {
        }
        else
        {
            // Text
        }
    }
