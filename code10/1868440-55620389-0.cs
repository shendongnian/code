    Dictionary<string, List<string>> myDict = new Dictionary<string, List<string>>();
    foreach (var it in uploadBox.Items)
    {
        if (it.ToString().Contains("Section"))
        {
            section = it.ToString().Substring(0, 18);
            found = it.ToString().IndexOf("_");
            section = section.Substring(found + 1);
            sectionNum = section.Substring(8, 2);
    		
    		if(!myDict.ContainsKey(sectionNum))
    		{
    			myDict.Add(sectionNum, new List<string> { someOtherValue });
    		}
    		else
    		{
    			myDict[sectionNum].Add(someOtherValue);
    		}
        }
    }
