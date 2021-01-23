    using System;
    using System.Collections.Generic;
    class Foo
    {
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
    
    class Program
    {
        public static void Main()
        {
            Dictionary<object, object> d = new Dictionary<object, object>();
            d["bar"] = 42;
    
            object s;
            Foo foo = new Foo();
            if (d.TryGetValue(foo, out s))   // results in NotImplementedException
            {
                Console.WriteLine("found");
            }
        }
    }
