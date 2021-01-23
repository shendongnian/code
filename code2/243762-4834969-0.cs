    class Foo : IEquatable<Foo>
        {
            private int _fooField1;
            public Foo(int value)
            {
                _fooField1 = value;
            }
    
            public override bool Equals(object obj)
            {
                return Equals(obj as Foo);
            }
    
            public bool Equals(Foo other)
            {
                return (other._fooField1 == this._fooField1);
            }
        }
    
    
    
        class Program
        {
            static void SomeFunction()
            {
                var Q = new Queue<Foo>();
                Foo fooInstance1 = new Foo(5);
                Foo fooInstance2 = new Foo(5);
    
                Q.Enqueue(fooInstance1);
                if (!Q.Contains(fooInstance2))
                {
                    Q.Enqueue(fooInstance2);
                }
                else
                {
                    Console.Out.WriteLine("Q already contains an equivalent instance ");
                }
            }
    
            static void Main(string[] args)
            {
                SomeFunction();
            }
        }
