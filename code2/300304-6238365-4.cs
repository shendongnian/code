    using System;
    
    public struct Foo
    {
        public static implicit operator Bar(Foo input)
        {
            Console.WriteLine("Foo to Bar");
            return new Bar();
        }
    
        public static implicit operator Baz(Foo input)
        {
            Console.WriteLine("Foo to Baz");
            return new Baz();
        }
    }
    
    public struct Bar
    {
        public static implicit operator Baz(Bar input)
        {
            Console.WriteLine("Bar to Baz");
            return new Baz();
        }
    }
    
    public struct Baz
    {
    }
    
    
    class Test
    {
        static void Main()
        {
            Foo? x = new Foo();
            Bar? y = new Bar();
            Baz? z = new Baz();
            
            Console.WriteLine("Unbracketed:");
            Baz? a = x ?? y ?? z;
            Console.WriteLine("Grouped to the left:");
            Baz? b = (x ?? y) ?? z;
            Console.WriteLine("Grouped to the right:");
            Baz? c = x ?? (y ?? z);
        }
    }
