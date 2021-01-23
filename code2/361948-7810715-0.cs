    namespace ClassLibrary1
    {
        [Export]
        public class Class1
        {
            [Import]
            public Class2 myclass;
        }
    
        [Export]
        public class Class2
        {
        }
    }
