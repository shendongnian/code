    public static Boolean IsBoolean(String s)
    {
        Boolean bit = false;
        return Boolean.TryParse(s, out bit);
    }
