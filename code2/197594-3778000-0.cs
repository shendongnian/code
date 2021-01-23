    static _selectors()
    {
    	for (int iKey = 0; iKey < match.Keys.ToList().Count; iKey++)
    	{
    		var type = match.Keys.ToList()[iKey];
    		_selectors.match[type] = new Regex(match[type].ToString() + @"(?![^\[]*\])(?![^\(]*\))");
    		_selectors.leftMatch[type] = new Regex(@"(^(?:.|\r|\n)*?)" + Regex.Replace(match[type].ToString(), @"\\(\d+)", (m) =>
    			@"\" + (m.Index + 1)));
    	}
    }
