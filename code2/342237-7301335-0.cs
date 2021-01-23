    private static readonly Regex searchTermRegex = new Regex(
    		@"^(
    			\s*
    			(?<term>
    				((?<prefix>[a-zA-Z][a-zA-Z0-9-_]*):)?
    				(?<termString>
    					(?<quotedTerm>
    						(?<quote>['""])
    						((\\\k<quote>)|((?!\k<quote>).))*
    						\k<quote>?
    					)
    					|(?<simpleTerm>[^\s]+)
    				)
    			)
    			\s*
    		)*$",
    	    RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.ExplicitCapture
    	);
    
    
    private static void FindTerms(string s) {
    	Console.WriteLine("[" + s + "]");
    	Match match = searchTermRegex.Match(s);
    	foreach(Capture term in match.Groups["term"].Captures) {
    		Console.WriteLine("term: " + term.Value);
    		
    		Capture prefix = null;
    		foreach(Capture prefixMatch in match.Groups["prefix"].Captures)
    			if(prefixMatch.Index >= term.Index && prefixMatch.Index <= term.Index + term.Length) {
    				prefix = prefixMatch;
    				break;
    			}
    		
    		if(null != prefix)
    			Console.WriteLine("prefix: " + prefix.Value);
    			
    		Capture termString = null;
    		foreach(Capture termStringMatch in match.Groups["termString"].Captures)
    			if(termStringMatch.Index >= term.Index && termStringMatch.Index <= term.Index + term.Length) {
    				termString = termStringMatch;
    				break;
    			}
    		Console.WriteLine("termString: " + termString.Value);
    	}
    	Console.WriteLine();
    }
    
    public static void Main (string[] args)
    {			
    	FindTerms(@"two terms");
    	FindTerms(@"prefix:value");
    	FindTerms(@"some:""quoted term""");
    	FindTerms(@"firstname:Jack ""the Ripper""");
    	FindTerms(@"'quoted term\'s escaped quotes'");
    	FindTerms(@"""unterminated quoted string");
    }
