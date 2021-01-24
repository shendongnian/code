    public class OuterClass
    {
       // other methods and fields... 
        public InnerClass InnerClassProp { get; } = new InnerClass();
    
        public class InnerClass {
            public int Prop1 { get; set; }
            public int Prop2 { get; set; }
        }
    }
    
    outerClassobject.InnerClassProp.Prop1 = 234;
