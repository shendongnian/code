    public void MyClass<T> where T : IEquatable<Foo>
    {
        private static readonly Foo SpecialFoo = Foo.SpecialFoo;
        public void MyMethodThatProcessesTs(T theT)
        {
            if (theT.Equals(SpecialFoo))
            {
                // process theT.
            }
        }
    }
