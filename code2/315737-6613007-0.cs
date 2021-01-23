    sealed class MyProxyList : IList<Derived>
    {
        IList<IBase> underlyingList;
        public MyProxyList(IList<IBase> underlyingList)
        {
            this.underlyingList = underlyingList;
        }
        ... now implement every member of IList<Derived> as a call to underlyingList with a cast where necessary ...
    }
