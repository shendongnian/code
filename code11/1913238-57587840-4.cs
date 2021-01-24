    public sealed class MyClassBuilder
    {
        public MyClass Build()
        {
            if (!_prop1Set || !_prop2Set || !_prop3Set)
                throw new InvalidOperationException("Not all properties set.");
            return new MyClass(_prop1, _prop2, _prop3);
        }
        public MyClassBuilder Prop1(int value)
        {
            _prop1    = value;
            _prop1Set = true;
            return this;
        }
        public MyClassBuilder Prop2(string value)
        {
            _prop2    = value;
            _prop2Set = true;
            return this;
        }
        public MyClassBuilder Prop3(DateTime value)
        {
            _prop3    = value;
            _prop3Set = true;
            return this;
        }
        int      _prop1;
        string   _prop2;
        DateTime _prop3;
        bool _prop1Set;
        bool _prop2Set;
        bool _prop3Set;
    }
