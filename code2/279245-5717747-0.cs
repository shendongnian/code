    static int MyIntegerParse(string possibleInt)
    {
        if (string.IsNullOrEmpty(possibleInt) || possibleInt.Length < 2)
        { 
            return 0;
        }
        int i;
        return int.TryParse(possibleInt.Substring(2), out i) ? i : 0;        
    }
