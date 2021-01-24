    string strRegex = @"(?<startDate>(.*\s*).*)\((?<startZone>.*)\)(?<endDate>(.*\s*).*)\((?<endZone>.*)\)";
    Regex myRegex = new Regex(strRegex, RegexOptions.Multiline | RegexOptions.Singleline);
    string dateRange = @"Wed Jan 08 2020 00:00:00 GMT-0500 (Eastern Standard Time)Sat Jan 25 2020 00:00:00 GMT-0500 (Eastern Standard Time)";
    
    Match myMatch = myRegex.Match(dateRange);
    	
    string startDate = myMatch.Groups["startDate"].Value;
    string endDate = myMatch.Groups["endDate"].Value;
    Console.WriteLine(startDate);
    Console.WriteLine(endDate);	
			
