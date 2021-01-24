    public class A : ICommon, IEquatable<A>
    {
        static readonly CommonComparer comparer = new CommonComparer();
        public int SomeInt { get; }
        public bool SomeBool { get; }
        public float SomeFloat { get; }
        private readonly string _someARelatedStuff;
        // Rest of class...
        public A(ICommon other, string someARelatedStuff)
            : this(other.SomeInt, other.SomeBool, other.SomeFloat, someARelatedStuff)
        { }
        public A(int someInt, bool someBool, float someFloat, string someARelatedStuff)
        {
            this.SomeInt = someInt;
            this.SomeBool = someBool;
            this.SomeFloat = someFloat;
            this._someARelatedStuff = someARelatedStuff;
        }
        public override string ToString() => _someARelatedStuff;
        #region IEquatable Members
        public override bool Equals(object obj)
        {
            if (obj is A other)
            {
                return Equals(other);
            }
            return false;
        }
        public virtual bool Equals(A other)
        {
            return comparer.Equals(this, other)
                && _someARelatedStuff.Equals(other._someARelatedStuff);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hc = comparer.GetHashCode(this);
                hc = (-1521134295)*hc + _someARelatedStuff.GetHashCode();
                return hc;
            }
        }
        #endregion
    }
    public class B : ICommon, IEquatable<B>
    {
        static readonly CommonComparer comparer = new CommonComparer();
        public int SomeInt { get; }
        public bool SomeBool { get; }
        public float SomeFloat { get; }
        readonly string _someBRelatedStuff;
        readonly double _someOtherBRelatedStuff;
        // Rest of class...
        public B(ICommon other, string someBRelatedStuff, double someOtherBRelatedStuff)
            : this(other.SomeInt, other.SomeBool, other.SomeFloat, someBRelatedStuff, someOtherBRelatedStuff)
        { }
        public B(int someInt, bool someBool, float someFloat, string someBRelatedStuff, double someOtherBRelatedStuff)
        {
            this.SomeInt = someInt;
            this.SomeBool = someBool;
            this.SomeFloat = someFloat;
            this._someBRelatedStuff = someBRelatedStuff;
            this._someOtherBRelatedStuff = someOtherBRelatedStuff;
        }
        public override string ToString() => $"{_someBRelatedStuff}, {_someOtherBRelatedStuff.ToString("g4")}";
        #region IEquatable Members
        public override bool Equals(object obj)
        {
            if (obj is B other)
            {
                return Equals(other);
            }
            return false;
        }
        public virtual bool Equals(B other)
        {
            return comparer.Equals(this, other)
                && _someBRelatedStuff.Equals(other._someBRelatedStuff)
                && _someOtherBRelatedStuff.Equals(other._someOtherBRelatedStuff);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hc = comparer.GetHashCode(this);
                hc = (-1521134295)*hc + _someBRelatedStuff.GetHashCode();
                hc = (-1521134295)*hc + _someOtherBRelatedStuff.GetHashCode();
                return hc;
            }
        }
        #endregion
    }
