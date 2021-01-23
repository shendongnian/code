    // implicit interface implementation
    // generates compile error "Explicit interface implementation"
    public class Foo1 : IBar
    {
        private Action<dynamic> foo;
        public event Action<dynamic> OnSomeEvent
        {
            add { foo += value; }
            remove { foo -= value; }
        }
    }
    // implicit interface implementation
    // generates compile error "Not supported by the language"
    public class Foo2 : IBar
    {
        private Action<dynamic> foo;
        event Action<dynamic> IBar.OnSomeEvent
        {
            add { foo += value; }
            remove { foo -= value; }
        }
    }
