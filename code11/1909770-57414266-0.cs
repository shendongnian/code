    string strRegex = @"(\d+)";
	Regex myRegex = new Regex(strRegex, RegexOptions.None);
	string strTargetString = @"HRA 1000000 and TDA 120000 and other benefits";
		
	foreach(Match match in myRegex.Matches(strTargetString))
	{
		strTargetString = strTargetString.Replace(match.Value, 
                                     string.Format("{0:n}", decimal.Parse(match.Value, System.Globalization.NumberStyles.Any)));			
	}
