    public string EvenColumns(int desiredWidth, IEnumerable<IEnumerable<string>> lists) {
    	return string.Join(Environment.NewLine, EvenColumns(desiredWidth, true, lists));
    }
    
    public IEnumerable<string> EvenColumns(int desiredWidth, bool rightOrLeft, IEnumerable<IEnumerable<string>> lists) {
    	return lists.Select(o => EvenColumns(desiredWidth, rightOrLeft, o.ToArray()));
    }
    
	public string EvenColumns(int desiredWidth, bool rightOrLeftAlignment, string[] list, bool fitToItems = false) {
		// right alignment needs "-X" 'width' vs left alignment which is just "X" in the `string.Format` format string
		int columnWidth = (rightOrLeftAlignment ? -1 : 1) *
							// fit to actual items? this could screw up "evenness" if
							// one column is longer than the others
							// and you use this with multiple rows
							(fitToItems
								? Math.Max(desiredWidth, list.Select(o => o.Length).Max())
								: desiredWidth
							);
		
		// make columns for all but the "last" (or first) one
		string format = string.Concat(Enumerable.Range(rightOrLeftAlignment ? 0 : 1, list.Length-1).Select( i => string.Format("{{{0},{1}}}", i, columnWidth) ));
		
		// then add the "last" one without Alignment
		if(rightOrLeftAlignment) {
			format += "{" + (list.Length-1) + "}";
		}
		else {
			format = "{0}" + format;
		}
		
		return string.Format(format, list);
	}
