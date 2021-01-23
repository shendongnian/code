        foreach (Match m in Regex.Matches(haystack, needle))
        {
        	int startLine = 1, endLine = 1;
        	// You could make it to return false if this fails.
        	// But lets assume the index is within text bounds.
        	if (m.Index < haystack.Length)
        	{
        		for (int i = 0; i <= m.Index; i++)
        			if (Environment.NewLine.Equals(haystack[i]))
        				startLine++;
        		endLine = startLine;
        
        		for (int i = m.Index; i <= (m.Index + needle.Length); i++)
        			if (Environment.NewLine.Equals(haystack[i]))
        				endLine++;
        	}
        
        	richTextBox1.Text += string.Format(
    "\nFound @ {0} Line {1} to {2}", m.Index, startLine, endLine);
