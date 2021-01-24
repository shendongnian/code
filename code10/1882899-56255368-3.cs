    public static IEnumerable<string> SplitBackward(string input, char c, int n)
    {
        var items = input.Split(c);
        var x = 0;
        var take = items.Length%n;
        while(x<items.Length)
        {
            if(take == 0) take = n;
            yield return String.Join(c.ToString(), items.Skip(x).Take(take));
            x += take;
            take = n;
        }
    }
