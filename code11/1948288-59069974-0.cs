    return Regex.Replace(
    			input, 
    			string.Format(@"(<{0}>.*?</{0}>)|(?<!\w)(?:{1})(?!\w)", tag,
    				string.Join("|", 
    					phrase.Trim().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
    						.Select(x => Regex.Escape(HttpUtility.HtmlEncode(x)))
    				)
    			), 
    			m => m.Groups[1].Success ? m.Groups[1].Value : string.Format("<{0}>{1}</{0}>", tag, m.Value), 
    			RegexOptions.IgnoreCase
    		);
