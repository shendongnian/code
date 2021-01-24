    public static bool IsAllLetter(string name)
    {
        if(string.IsNullOrEmpty(name))
            return false;
        foreach (char c in name)
        {
            if (!char.IsLetter(c) || name == null)
            {
                return false;
            }
        }
        return true;
    }
