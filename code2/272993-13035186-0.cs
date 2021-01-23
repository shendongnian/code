	protected static bool CheckValidFormatHtmlColor(string inputColor)
	{
           //regex from http://stackoverflow.com/a/1636354/2343
           if (Regex.Match(inputColor, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success)
	           return true;
			
  	       var result = System.Drawing.Color.FromName(inputColor);
   	       return result.IsKnownColor;
	}
