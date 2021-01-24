            //I'm sure there are much more effecient ways to determine this multiplier...
    private List<double> DivTester(List<double> rem, List<double> denom)
    {
        //declairing a new list for testing, starting value of 1
        List<double> ten = new List<double>()
        {
            10
        };
        //create and set the dCopy = denom
        List<double> dCopy = new List<double>();
        for (int i = 0; i < denom.Count; i++)
        {
            dCopy.Add(denom[i]);
        }
        //create and set the testerPass = 1
        List<double> testerPass = new List<double>()
        {
            1
        };
        //getting a starting value
        string compareResult = WhichIsBigger(rem, dCopy);
        while(compareResult == "A")
        {
            dCopy = SuperMultiply(dCopy, ten);
            //check and see if it is still successfull
            compareResult = WhichIsBigger(rem, dCopy);
            //if it passes, multiple testerPass by ten
            if (compareResult == "A")
            {
                testerPass = SuperMultiply(testerPass, ten);
            }
        }
        //return the largest multipler (10^X) that can be safely used
        return testerPass;        
    }
