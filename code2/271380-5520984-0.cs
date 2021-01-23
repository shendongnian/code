    Regex outer = new Regex(@"STARTREPLACEME.+ENDREPLACEME", RegexOptions.Compiled);
    Regex inner = new Regex(@"\^", RegexOptions.Compiled);
    string replaced = outer.Replace(start, m =>
    {
        return inner.Replace(m.Value, String.Empty);
    });
