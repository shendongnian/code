    public static string foo(string s, char c, int count)
    {
        var i = 0;
        return string.Concat(s.TakeWhile(x => (x == c ? i++ : i) < count));
    }
