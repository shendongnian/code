    class C
    { 
        private MyEnum foo = MyEnum.Something;
        public MyEnum Foo 
        {
            get { return foo; }
            set { }
        }
        void DoSomething()
        {
            Foo = MyEnum.SomethingElse; // does nothing
        }
    }
