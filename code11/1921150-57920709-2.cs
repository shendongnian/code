    public static void IsAllLetter(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) || name == null)
            {
                return false;
            }
        }
        return true;
    }
