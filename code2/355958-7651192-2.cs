    public static string Shorten(this string name, int chars)
    {
        if (name.ToCharArray().Count() > chars)
        {
            return name.Substring(0, chars) + "...";
        }
        else return name;
    }
