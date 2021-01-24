    var result = RleString("aaaabbccaa");
    private static IEnumerable<(char chr, int count)> Rle(string s)
    {
        if (string.IsNullOrEmpty(s)) yield break;
        var lastchar = s.First(); // or s[0]
        var count = 1;
        foreach (char letter in s.Skip(1))
        {
            if (letter != lastchar)
            {
                yield return (lastchar, count);
                lastchar = letter;
                count = 0;
            }
            count++;
        }
        if (count > 0)
            yield return (lastchar, count);
    }
	private static string RleString(string s)
	{
		return String.Join("",Rle(s).Select(z=>$"{z.count}{z.chr}"));
	}
