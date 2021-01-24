            public class Inner
            {
                public Inner(int value)
                {
                    Value = value;
                }
                public int Value { get; }
            }
            public class Outer
            {
                public Outer(Inner inner)
                {
                    InnerObject = inner;
                }
                public Inner InnerObject { get;}
            }
            public class main
            {       
        
                static void Main()
                {
                    var outer = new Outer(new Inner(10));
                    Console.WriteLine(outer.InnerObject.Value);
                    var value = outer.InnerObject.Value;
                }
            }
