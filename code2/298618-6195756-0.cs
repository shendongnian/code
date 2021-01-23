    bool hasUpperCase (string str) {
    if(string.IsNullOrEmpty(str))
         return false;
    for (int i = 0; i < str.Length; i= i + 2) {
        if (char.IsUpper (str[i]))
            return true;                    
        if ((i + 1) < str.Length && char.IsUpper (str[i+1]))
            return true;                    
    }
    return false;
