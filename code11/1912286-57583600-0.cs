            //assumes both inputs are positive and > 0
    public List<double> SuperDivide(List<double> numerator, List<double> denominator)
    {
        //here we are going to adopt the notation used on the wiki page for long division
        //inputs are numerator/denominator
        //outputs are (Q,R) quotient and remainder
        //create and set the Q to 0
        List<double> quotient = new List<double>
        {
            0
        };
        //create a list of value 1
        List<double> one = new List<double>
        {
            1
        };
        //declairing a new list to house the result
        List<double> resultValue = new List<double>();
        //empty strings to hold the #'s
        string denomString = "";
        string remainderString = "";
        //create and set the R = N
        List<double> remainder = new List<double>();
        for (int i = 0; i < numerator.Count; i++)
        {
            remainder.Add(numerator[i]);
        }
        //getting a starting value
        string compareResult = WhichIsBigger(remainder, denominator);
        //calculate Q and R: while R >= D
        while(compareResult =="A" || compareResult == "Equal")
        {
            //get the multiplier we can use to save calcs on big # results (xxxxxxxxxxxxxxxxxxx / yyyy)
            List<double> testResult = DivTester(remainder, denominator);
            //create a var for D * X, where X is the testResult
            List<double> denomMult = SuperMultiply(denominator, testResult);
            //Q = Q + X
            quotient = SuperAdd(quotient, testResult);
            //R = R - DX
            remainder = SuperSubtract(remainder, denomMult);
            compareResult = WhichIsBigger(remainder, denominator);
        }
        //if R = 0, return Q
        if(remainder.Count == 1 && remainder[0] == 0)
        {
            return quotient; 
        }
        //else return Q + (R/D)
        else
        {
            //get the stopping position for the for loops (clamped at 5 due to double having a precision of 15 digits)
            int stopPosR = remainder.Count - Mathf.Clamp(remainder.Count, 1, 5);
            int stopPosD = denominator.Count - Mathf.Clamp(denominator.Count, 1, 5);
            //create a string of the largest digits in R
            if (stopPosR > 1)
            {
                for (int i = remainder.Count - 1; i >= stopPosR; i--)
                {
                    //starting tier (largest #)
                    if (i == remainder.Count - 1)
                    {
                        remainderString = remainder[i].ToString();
                    }
                    else
                    {
                        if (remainder[i] < 10) remainderString = remainderString + "00" + remainder[i].ToString();
                        else if (remainder[i] < 100) remainderString = remainderString + "0" + remainder[i].ToString();
                        else remainderString = remainderString + remainder[i].ToString();
                    }
                }
            }
            else
            {
                for (int i = remainder.Count - 1; i >= 0; i--)
                {
                    //starting tier (largest #)
                    if (i == remainder.Count - 1)
                    {
                        remainderString = remainder[i].ToString();
                    }
                    else
                    {
                        if (remainder[i] < 10) remainderString = remainderString + "00" + remainder[i].ToString();
                        else if (remainder[i] < 100) remainderString = remainderString + "0" + remainder[i].ToString();
                        else remainderString = remainderString + remainder[i].ToString();
                    }
                }
            }
            //create a string of the largest digits in D
            if (stopPosD > 1)
            {
                for (int i = denominator.Count - 1; i >= stopPosD; i--)
                {
                    if (i == denominator.Count - 1)
                    {
                        denomString = denominator[i].ToString();
                    }
                    else
                    {
                        if (denominator[i] < 10) denomString = denomString + "00" + denominator[i].ToString();
                        else if (denominator[i] < 100) denomString = denomString + "0" + denominator[i].ToString();
                        else denomString = denomString + denominator[i].ToString();
                    }
                }
            }
            else
            {
                for (int i = denominator.Count - 1; i >= 0; i--)
                {
                    if (i == denominator.Count - 1)
                    {
                        denomString = denominator[i].ToString();
                    }
                    else
                    {
                        if (denominator[i] < 10) denomString = denomString + "00" + denominator[i].ToString();
                        else if (denominator[i] < 100) denomString = denomString + "0" + denominator[i].ToString();
                        else denomString = denomString + denominator[i].ToString();
                    }
                }
            }
            //create numbers for divsion of R/D
            double remainderDoub = double.Parse(remainderString);
            double denomDoub = double.Parse(denomString);
            //adjust for one being bigger than the other, only by relative amount though
            //only needed when one of them has 6+ tiers
            if (remainder.Count > 5 && denominator.Count > 5)
            {
                if (remainder.Count > denominator.Count)
                {
                    remainderDoub *= Math.Pow(1000, remainder.Count - denominator.Count);
                }
                else if (remainder.Count < denominator.Count)
                {
                    denomDoub *= Math.Pow(1000, denominator.Count - remainder.Count);
                }
            }
            resultValue.Add(remainderDoub / denomDoub);
            resultValue = SuperAdd(resultValue, quotient);
            return resultValue;
        }
    }
