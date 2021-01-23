	MatchCollection mC = Regex.Matches(lines[idx], "@?\"([^\"]+)\"");
	
	foreach (Match m in mC)
    {                           
                            
		if (			
			// Detect format insertion markers that are on their own and ignore them, 
			!Regex.IsMatch(m.Value, @"""\s*\{\d(:\d+)?\}\s*""") &&
			//or check for strings of single character length that are not proper characters (-, /, etc)
			!Regex.IsMatch(m.Value, @"""\s*\\?[^\w]\s*""") &&
			//check for digit only strings, allowing for decimal places and an optional percentage or multiplier indicator
			!Regex.IsMatch(m.Value, @"""[\d.]+[%|x]?""") &&
			//check for array indexers
			!(m.Index <= lines[idx].Length && lines[idx][m.Index - 1] == '[' && lines[idx][m.Index + m.Length] == ']')  &&			
			)
		{
			String toCheck = m.Groups[1].Value;
	
			//look up the string we found in our list of constants
			if (constantList.ContainsKey(toCheck))
			{
				String replaceString;
					
				replaceString = "Constants." + constants[toCheck];				
				//replace the line in the file
				lines[idx] = lines[idx].Replace("\"" + m.Groups[1].Value + "\"", replaceString);
			}
			else
			{
				
				//See Point 8....
			}
		}
