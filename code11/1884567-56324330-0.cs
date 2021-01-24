            public MainWindowViewModel()
        {
            MyType Type1 = new MyType();
            MyType Type2 = new MyType();
            MyItems.Add(Type1);
            MyItems.Add(Type2);
            Type1.SetPair(ref Type2);
        }
