    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        public int i;
        internal void <M>b__0(int x)
        {
            Console.WriteLine(x + i);
        }
    }
    public void M(int i)
    {
        <>c__DisplayClass0_0 <>c__DisplayClass0_ = new <>c__DisplayClass0_0();
        <>c__DisplayClass0_.i = i;
        new Action<int>(<>c__DisplayClass0_.<M>b__0)(<>c__DisplayClass0_.i + 1);
    }
