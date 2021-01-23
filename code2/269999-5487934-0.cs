    public string StripAfterLastNumber(string input)
    {
    	//+1 because index is zero based
    	int charsToTake = input.LastIndexOf(input.Last(c => char.IsNumber(c))) + 1;
    
    	return input.Take(charsToTake).ToArray;
    }
