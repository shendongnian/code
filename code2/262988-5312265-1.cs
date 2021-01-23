    public static System.String CutStart(this System.String s, System.String what)
    {
        if (s.StartsWith(what))
            return s.Substring(what.Length);
        else
            return s;
    }
