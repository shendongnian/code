    var placementOneList = new List<string>();
    var placementTwoList = new List<string>();
    var placementUserDefinedList = new List<string>();
    		
    // For each line in the file
    foreach(string line in File.ReadAllLines("filename"))
    {
    	// Split the line to get only the "whatIWantToMatch" token
    	// (Error handling omitted for simplicity)
    	var match = line.Split(new String[] {" ", "\t"}, 
    		StringSplitOptions.RemoveEmptyEntries)[5];
    			
    	// Put the line in the appropriate list depending upon its "whatIWantToMatch" value
    	if(match.StartsWith("RES.") { placementOneList.Add(line); }
        else if(match.StartsWith("0603.") { placementOneList.Add(line); }
        // ...
        else if(match.StartsWith("BGA.") { placementTwoList.Add(line); }
        // ...
        else { throw new ApplicationException(); } // No match found
    }
