    private static int[] ParseInt(string s)
    {
        var t = ParseString(s);
        var i = t.Select(x => int.Parse(x));
        return i.ToArray();
    }
Using method groups:
    private static int[] ParseInt(string s)
    {
        var t = ParseString(s);
        var i = t.Select(int.Parse);
        return i.ToArray();
    }
