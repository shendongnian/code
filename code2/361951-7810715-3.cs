    namespace ClassLibrary1
        {
            [Export]
            public class Class1
            {
                [ImportingConstructor]
                public Class1(Class2 c2)
                {
                    myclass = c2;
                }
    
                public Class2 myclass;
            }
        
            [Export]
            public class Class2
            {
            }
        }
