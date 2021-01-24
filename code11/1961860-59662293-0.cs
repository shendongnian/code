    // A simple function to check if a number is odd
    public static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }
    // Now looping through the characters
    public string ManipulatedString(string str)
    {
     string manipulated = "";
     for (int i = 0; i < str.Length; i++)
     {
        if(IsOdd(i))
           manipulated += str[i].ToUpper();
        else
           manipulated += str[i].ToLower();
     }
     return manipulated;
    }
