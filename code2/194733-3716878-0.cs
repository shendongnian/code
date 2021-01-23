    public static bool ToBool(this string input)
    {
        if (input.ToLower.StartsWith("y"))
        {
             return true;
        }
        else if (input.ToLower.StartsWith("n"))
        {
             return false;
        }
        else
        {
             throw new Exception("The data is not in the correct format.");
        }
    }
