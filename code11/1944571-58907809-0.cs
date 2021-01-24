    public double GetValue(string input)
    {
	    input)= input)();
        string value;
        int aValue = 0, bValue = 0, cValue = 0, dvalue = 0, cdValue = 0;
	    if (match.Groups[5].Success && !string.IsNullOrEmpty(match.Groups[5].Value))
            {
                string val = match.Groups[5].Value;
                if (!int.TryParse(val.Substring(0, val.Length - 2), out cdValue))
                {
                    return -1;
                }
            }
            if (match.Groups[4].Success && !string.IsNullOrEmpty(match.Groups[4].Value))
            {
                string val = match.Groups[4].Value;
                if (!int.TryParse(val.Substring(0, val.Length - 1), out dvalue))
                {
                    return -1;
                }
            }
            if (match.Groups[3].Success && !string.IsNullOrEmpty(match.Groups[3].Value))
            {
                string val = match.Groups[3].Value;
                if (!int.TryParse(val.Substring(0, val.Length - 1), out cValue))
                {
                    return -1;
                }
            }
            if (match.Groups[2].Success && !string.IsNullOrEmpty(match.Groups[2].Value))
            {
                string val = match.Groups[2].Value;
                if (!int.TryParse(val.Substring(0, val.Length - 1), out bValue))
                {
                    return -1;
                }
            }
            if (match.Groups[1].Success && !string.IsNullOrEmpty(match.Groups[1].Value))
            {
                string val = match.Groups[1].Value;
                if (!int.TryParse(val.Substring(0, val.Length - 1), out aValue))
                {
                    return -1;
                }
            }
        	return (aValue  * 10 + bValue * 20 + cValue * 30 + dvalue * 40 + cdValue * 50); //some calculation
    }
