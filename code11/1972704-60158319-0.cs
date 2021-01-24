     public static bool IsNumber(char character)
     {
        try
        {
           int.Parse(character.ToString(), CultureInfo.CurrentCulture);
           return true;
        }
           catch (FormatException) { return false; }
     }
