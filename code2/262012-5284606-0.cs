    public static string RemoveFromLength(this string s, string suffix)
    {
        if (s.EndsWith(suffix))
        {
            return s.SubString(0, s.Length - suffix.Length);
        }
        else
        {
            return s;
        }
    }
