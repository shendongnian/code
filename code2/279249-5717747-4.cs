    static int MyIntegerParse(string possibleInt)
    {
        int i;
        return (!string.IsNullOrEmpty(possibleInt) 
            && possibleInt.Length >= 2
            && int.TryParse(possibleInt.Substring(2), out i)) ? i : 0;        
    }
