    public class Outer
    {
        private static Action<Inner, string> InnerAttributeSetter;
    
        public class Inner
        {
            static Inner()
            {
                Outer.InnerAttributeSetter = (inner, att) => inner.Attribute = att;
            }
    
            public string Attribute { get; private set; }
        }
    
        public Outer()
        {
            var inner = new Inner();
    
            InnerAttributeSetter(inner, "Value");
    
            Console.WriteLine(inner.Attribute);
        }
    }
