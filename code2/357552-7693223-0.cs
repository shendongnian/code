    class FooComparer: IEqualityComparer<FooClass>
    {
        public bool Equals(FooClass f1, FooClass f2)
        {
            return (f1.FirstName == f2.FirstName) && (f1.LastName == f2.LastName);
        }
        public int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }
    }
