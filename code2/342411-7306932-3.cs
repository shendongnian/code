    /// Get / Set the extended properties of the FTPS processor
    /// </summary>
    /// <remarks>Can't serialize the Dictionary object so convert to a string (http://msdn.microsoft.com/en-us/library/ms950721.aspx)</remarks>
    public Dictionary<string, string> FtpsExtendedProperties
    {
	get 
	{
	
	Dictionary<string, string> dict = m_FtpsExtendedProperties.Split('|')
		  .Select(s => s.Split(','))
		  .ToDictionary(key => key[0].Trim(), value => value[1].Trim());
		return dict; 
	}
	set 
	{
            // NOTE: for large dictionaries, this can use
            // a StringBuilder instead of a string for cumulativeText
            // does not preserve Dictionary order (if that is important - reorder the String.Format)
	    string newProperties = 
    		      value.Aggregate ("",
                          (cumulativeText,kvp) => String.Format("{0},{1}|{2}", kvp.Key, kvp.Value, cumulativeText));
    
            // Remove the last pipe serperator
            newProperties = newProperties.Substring(0, newProperties.Length - 1);
    		
        	}
        }
