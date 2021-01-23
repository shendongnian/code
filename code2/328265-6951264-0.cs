    class Foo 
    {
        class Bar // nested
        {
            private int _value;
            public int Value 
            {
                get { return _value; }
                set { _value = value; /* logic */ }
            }
        }
    }
