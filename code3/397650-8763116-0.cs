    private double ParseDoubleFromString(string num)
    {
        //removes multiple spces between characters, cammas, and leading/trailing whitespace
        num = Regex.Replace(num.Replace(",", ""), @"\s+", " ").Trim();
        double d = 0;
        int whole = 0;
        double numerator;
        double denominator;
        //is there a fraction?
        if (num.Contains("/"))
        {
            //is there a space?
            if (num.Contains(" "))
            {
                //seperate the integer and fraction
                int firstspace = num.IndexOf(" ");
                string fraction = num.Substring(firstspace, num.Length - firstspace);
                //set the integer
                whole = int.Parse(num.Substring(0, firstspace));
                //set the numerator and denominator
                numerator = double.Parse(fraction.Split("/".ToCharArray())[0]);
                denominator = double.Parse(fraction.Split("/".ToCharArray())[1]);
            }
            else
            {
                //set the numerator and denominator
                numerator = double.Parse(num.Split("/".ToCharArray())[0]);
                denominator = double.Parse(num.Split("/".ToCharArray())[1]);
            }
            //is it a valid fraction?
            if (denominator != 0)
            {
                d = whole + (numerator / denominator);
            }
        }
        else
        {
            //parse the whole thing
            d = double.Parse(num.Replace(" ", ""));
        }
        
        return d;
    }
