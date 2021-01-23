    delegate string StringModifier(string data);
    public void Test()
    {
    	StringModifier removeQuotes = (data) => data.Replace("\"", "");
    	string blah = "testotest\"testeste";
    	string bluh = removeQuotes(blah); // returns "testotesttesteste";
    }
