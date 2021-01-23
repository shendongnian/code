    static _selectors()
    {
    	List<string> keys = match.Keys.ToList();
    	for (int iKey = 0; iKey < keys.Count; iKey++)
    	{
    		var type = keys[iKey];
    		_selectors.match[type] = new Regex(match[type].ToString() + @"(?![^\[]*\])(?![^\(]*\))");
    		_selectors.leftMatch[type] = new Regex(@"(^(?:.|\r|\n)*?)" + Regex.Replace(match[type].ToString(), @"\\(\d+)", (m) =>
    			@"\" + (m.Index + 1)));
    	}
    }
