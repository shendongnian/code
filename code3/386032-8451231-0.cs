    //This could be inlined to the row below if you wanted
    Regex oRE = new Regex(@"\s*\,\s*");
    string TestString = ",, test , TEST 2   ,Test3";
    //This is really the line you're looking for - the rest of the code just sets up an example
    string[] Results = oRE.Split(TestString.Trim());
    foreach(string S in Results){
    	Console.WriteLine(">>" + S + "<<");
    }
