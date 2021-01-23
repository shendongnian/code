    AdHocIFoo : IFoo
    {
        Func<int> get_mValue;
        public AdHocIFoo(Func<int> getValue)
        {
             this.get_mValue = getValue;
        }
        public int mValue { get { return get_mValue(); } }
    }
