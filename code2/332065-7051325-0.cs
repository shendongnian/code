      public class Foo : IEquatable<Foo>
        {
            public virtual bool Equals(Foo other)
            {
                return false;
            }
        }
    
        public class A : Foo
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
    
            public override bool Equals(Foo other)
            {
                if (other.GetType() == typeof(A))
                {
                    A second = (A)other;
                    return this.Number1 == second.Number1 && this.Number2 == second.Number2;
                }
                throw new InvalidOperationException("Object is not of type A");
            }
        }
    
        public class B : Foo
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public int Number3 { get; set; }
    
            public override bool Equals(Foo other)
            {
                if (other.GetType() == typeof(B))
                {
                    B second = (B)other;
                    return this.Number1 == second.Number1 && this.Number2 == second.Number2 && this.Number3 == second.Number3;
                }
                throw new InvalidOperationException("Object is not of type B");
            }
        }
