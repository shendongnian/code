        List<string> allTexts = new List<string>
		{ @"[{""Name_First"":""Mario"",""Entry_ID"":""72313""}]",
 		  @"[{""Name_Last"":""Rincon Recio"",""Entry_ID"":""72313""}]" };
		
        int total_FirstName = 0;
        int total_noFirstName = 0;
		foreach(var allText in allTexts)
		{
            var fields = JsonConvert.DeserializeObject<List<FirstName>>(allText);
	    	var test = JsonConvert.SerializeObject(fields);
	        Console.WriteLine(test);
            foreach (var split in fields)
            {
                if (split.Name_First != null)
                {
                    total_FirstName++;
	           	}
                else
                {
                    total_noFirstName++;
                }
            }
		}
	    int total = total_FirstName + total_noFirstName;
        Console.WriteLine(total);
        Console.WriteLine(total_noFirstName);
        Console.WriteLine(total_FirstName);
