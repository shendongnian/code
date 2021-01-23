    l.Sort(delegate(String One, String Two)
    {
        while (One != "" && Two != "")
        {
            if (One == Two)
                return 0;
            //Add one more group to capture what remains of the expression
            Match l_mOne = Regex.Match(One, @"_*(\D*)(\d*)(.*)$"); 
            Match l_mTwo = Regex.Match(Two, @"_*(\D*)(\d*)(.*)$");
            int Result;
            if (l_mOne.Success || l_mTwo.Success)
            {
                String l_strX, l_strY;
                l_strX = l_mOne.Groups[1].Value;
                l_strY = l_mTwo.Groups[1].Value;
                Result = l_strX.CompareTo(l_strY);
                if (Result != 0)
                    return Result;
                l_strX = l_mOne.Groups[2].Value;
                l_strY = l_mTwo.Groups[2].Value;
                if (l_strX == String.Empty || l_strY == String.Empty)
                {
                    Result = l_strX.CompareTo(l_strY);
                    if (Result != 0)
                        return Result;
                }
                else
                {
                    long X = long.Parse(l_strX);
                    long Y = long.Parse(l_strY);
                    Result = X.CompareTo(Y);
                    if (Result != 0)
                        return Result;
                    One = l_mOne.Groups[3].Value; //Store in 'One' the remaining part of the regex
                    Two = l_mTwo.Groups[3].Value; //The same in Two
                    continue; //The result will be the result of the comparison of those two new values.
                }
            }
        }
        return One.CompareTo(Two);
    });
