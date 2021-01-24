    public double[] GetRandomDoublesUnique(double lowerBounds, double upperBounds, int maxPrecision, int quantity)
        {
            if (lowerBounds >= upperBounds)
            {
                throw new Exception("Error in GetRandomDoublesUnique is: LowerBounds is greater than UpperBounds!");
            }
            //These next few lines are for the purpose of determining the maximum possible number of return values
            //possibleValues is populated to prevent a runaway condition that could occurs if the 
            //max possible values--at the given precision level--is less than the user-selected quantity.
            //i.e. if user selects 1 to 1.01, precision of 3, and quantity of 50, there would be a problem
            // if we didn't limit loop to the 11 possible values at precision of 3:  
            //1.000, 1.001, 1.002, 1.003, 1.004, 1.005, 1.006, 1.007, 1.008, 1.009, 1.010
            int lowerInt = (int)(lowerBounds * (double)Math.Pow(10, maxPrecision));
            int higherInt = (int)(upperBounds * (double)Math.Pow(10, maxPrecision));
            int possibleValues = higherInt - lowerInt + 1;
                
            //Create Dictionary to store number values already generated so we can ensure
            //we don't have duplicates
            Dictionary<double, int> myDoubles = new Dictionary<double, int>();
            double[] returnValues = new double[(quantity>possibleValues?possibleValues:quantity)];
            double NextValue;
            //Iterate through and generate values--limiting to both the user-selected quantity and # of possible values
            for (int i = 0; (i < quantity)&&(i<possibleValues); i++)
            {
                NextValue = GetRandomDouble(lowerBounds, upperBounds, maxPrecision);
                if (!myDoubles.ContainsKey(NextValue))
                {
                    myDoubles.Add(NextValue, i);
                    returnValues[i] = NextValue;
                }
                else
                {
                    i -= 1;
                }
            }
            return returnValues;
        }
