    public static IEnumerable<string> SplitForward(string input, char c, int n)
    {
        var items = input.Split(c);
        var x = 0;
        while(x<items.Length)
        {
            yield return String.Join(c.ToString(), items.Skip(x).Take(n));
            x += n;
        }
    }
