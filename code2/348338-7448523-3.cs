    string SplitCapital(string str)
    {
    	//Search all capital letters and store indexes
    	var indexes = str
    		.Select((c, i) => new { c = c, i = i }) // Select information about char and position
    		.Where(c => Char.IsUpper(c.c)) // Get only capital chars
    		.Select(cl => cl.i); // Get indexes of capital chars
    
    	// If no indexes found or if indicies count equal to the source string length then return source string
    	if (!indexes.Any() || indexes.Count() == str.Length)
    	{
    		return str;
    	}
    
    	// Create string builder from the source string
    	var sb = new StringBuilder(str);
        // Reverse indexes and remove 0 if necessary
    	foreach (var index in indexes.Reverse().Where(i => i != 0))
    	{
    		// Insert spaces before capital letter
    		sb.Insert(index, ' ');
    	}
    
    	return sb.ToString();
    }
    
    string SplitCapital(string str, out string[] parts)
    {
    	var splitted = SplitCapital(str);
    	parts = splitted.Split(new[] { ' ' }, StringSplitOptions.None);
    	return splitted;
    }
