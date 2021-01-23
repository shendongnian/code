    private static string Switch(this string text, char splitter)
    {
        if(text != null && text.Length > 2) //Needs at least 3 letters for a valid switch
    	{
    		int position = text.IndexOf(splitter);
    		if(position != -1) return text.Substring(position + 1) + splitter + text.Substring(0, position);
    	}
    	return text;
    }
    "99,-3432".Switch(',');
