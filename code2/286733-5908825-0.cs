    public class BaseFoo<TDerived> where TDerived : BaseFoo<TDerived>
    {
        private bool _myProp = false;
        public TDerived SetMyProperty()
        {
            this._myProp = true;
            return (TDerived)this;
        }
    }
    
    public class DerivedFoo : BaseFoo<DerivedFoo>
    {
        public bool _derivedProp = false;
        public DerivedFoo SetDerivedPropery()
        {
            this._derivedProp = true;
            return this;
        }
    }
