        string numbersStr = txtNumbersToBeExc.Text;
      	string startSeedStr = txtStartSeed.Text;
       	string endSeedStr = txtEndSeed.Text;
    
        
    	//next, the input type actually is of type int, we should test if the strings are ok ( they do represent ints)
    	var intAry = numbersStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s=>Int32.Parse(s));	
    	int startSeed = Int32.Parse(startSeedStr);
    	int endSeed = Int32.Parse(endSeedStr);
    	
    	/*FROM HERE*/
    	// using Enumerable.Range 
    	var genList = Enumerable.Range(startSeed, endSeed - startSeed + 1);
    	
    	// we can use linq except
    	var finalList = genList.Except(intAry);
    	
    	// do you need a string, for 700 concatenations I would suggest StringBuilder
    	var sb = new StringBuilder();
    	foreach ( var item in finalList)
    	{
    		sb.AppendLine(string.Concat("959",item.ToString()));
    	}
    	var finalString = sb.ToString();
    	/*TO HERE, refactor it into a method or class*/
    	
    	txtGeneratedNum.Text = finalString;
