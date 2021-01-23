    [Test]
    public void Replace_all_asterisks_outside_the_square_brackets()
    {
        var input = "H*]e*l[*o], w*rl[*d*o] [o*] [o*o].";
        var actual = ReplaceAsterisksNotInSquareBrackets(input);
        var expected = "H%]e%l[*o], w%rl[*d*o] [o*] [o*o].";
        
        Assert.AreEqual(expected, actual);
    }
    private static string ReplaceAsterisksNotInSquareBrackets(string s)
    {
        Regex rx = new Regex(@"(?<=\[[^\[\]]*)(?<asterisk>\*)(?=[^\[\]]*\])");
        var matches = rx.Matches(s);
        s = s.Replace('*', '%');
        foreach (Match match in matches)
        {
            s = s.Remove(match.Groups["asterisk"].Index, 1);
            s = s.Insert(match.Groups["asterisk"].Index, "*");
        }
        return s;
    }
