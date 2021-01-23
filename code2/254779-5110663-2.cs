    // Some classes
    class BaseTagMatch {
        public Capture Capture;
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
    // The code
    var pattern =
        "(?# line 01) ^" +
        "(?# line 02) (" +
        @"(?# line 03)   (?>(?<TEXT>[^\[]+))" +
        "(?# line 04)   |" +
        @"(?# line 05)   \[  (?<TAG>  (?<OPEN>[A-Z]*)  )  =?  (?<TAG_OPTION>(?:(?<==)[^\]]*)?)  \]  (?<BEGIN_INNER_TEXT>)" +
        "(?# line 06)   |" +
        @"(?# line 07)   (?>(?<END_INNER_TEXT>)  \[/  \k<OPEN>  \]  (?<-OPEN>))" +
        "(?# line 08)   |" +
        @"(?# line 09)   (?>(?<TEXT>\[))" +
        "(?# line 10) )*" +
        "(?# line 11) (?(OPEN)(?!))" +
        "(?# line 12) $";
    var rx = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);
    var match = rx.Match("[div=c:max max]asdf[p=1] a [p=2] [a]sd [/z]  [ [/p]f[/p]asdffds[/DIV] [p][/p]");
    ////var tags = match.Groups["TAG"].Captures.OfType<Capture>().ToArray();
    ////var tagoptions = match.Groups["TAG_OPTION"].Captures.OfType<Capture>().ToArray();
    ////var begininnertext = match.Groups["BEGIN_INNER_TEXT"].Captures.OfType<Capture>().ToArray();
    ////var endinnertext = match.Groups["END_INNER_TEXT"].Captures.OfType<Capture>().ToArray();
    ////var text = match.Groups["TEXT"].Captures.OfType<Capture>().ToArray();
    var tags = match.Groups["TAG"].Captures.OfType<Capture>().Select((p, ix) => new BeginTag {Capture = p, Index = ix, Options = match.Groups["TAG_OPTION"].Captures[ix]}).ToList();
    Func<Capture, int, EndTag> func = (p, ix) => {
                                            var temp = new EndTag {Capture = p, Index = ix, BeginTag = tags[ix]};
                                            tags[ix].EndTag = temp;
                                            return temp;
                                        };
    var endTags = match.Groups["END_INNER_TEXT"].Captures.OfType<Capture>().Select((p, ix) => func(p, ix));
    var text = match.Groups["TEXT"].Captures.OfType<Capture>().Select((p, ix) => new Text { Capture = p });
    // Here you have all the tags and the inner text neatly ordered and ready to be recomposed in a StringBuilder.
    var allTags = tags.Cast<BaseTagMatch>().Union(endTags).Union(text).ToList();
    allTags.Sort((p, q) => p.Capture.Index - q.Capture.Index);
    foreach (var el in allTags) {
        var type = el.GetType();
        if (type == typeof(BeginTag)) {
                    
        } else if (type == typeof(EndTag)) {
                    
        } else {
            // Text
        }
    }
