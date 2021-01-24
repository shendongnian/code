    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        public int length;
        internal bool <Query>b__0(string a)
        {
            return a.Length >= length;
        }
        internal string <Query>b__1(string a)
        {
            return a.Substring(0, length);
        }
    }
    public void Query(IEnumerable<string> items, int length)
    {
        <>c__DisplayClass0_0 <>c__DisplayClass0_ = new <>c__DisplayClass0_0();
        <>c__DisplayClass0_.length = length;
        Enumerable.Distinct(Enumerable.Select(Enumerable.Where(items, new Func<string, bool>(<>c__DisplayClass0_.<Query>b__0)), new Func<string, string>(<>c__DisplayClass0_.<Query>b__1)));
    }
