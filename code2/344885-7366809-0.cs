    class MyGeneric<T>
    {
        public int MyProperty { get; set; }
    
        static MyClass<T>
        {
            string lMyPropertyName = MembersOf<MyGeneric<T>>.GetName(x => x.MyProperty);
        }
    }
