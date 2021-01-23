    interface IAvalue
        {
            int Foo { get; set;}
            string Bar {get; set;}
        }
    
        struct BValue
            : IAvalue
        {
    
            public int Foo { get; set; }
            public string Bar { get; set; }
        }
    
        struct CValue
            : IAvalue
        {
            public int Foo { get; set; }
            public string Bar { get; set; }
    
        
        }
    
        abstract class A<T> where T : IAvalue
        {
            protected static T myValue;
        }
    
        class B : A<BValue>
        {
            static B()
            {
                myValue.Foo = 1;
                myValue.Bar = "text1";
            }
        }
    
        class C : A<CValue>
        {
            static C()
            {
                myValue.Foo = 2;
                myValue.Bar = "text2";
            }
        }
