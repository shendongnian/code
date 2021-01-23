    class FooEqualityComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            // implement Equals between x and y
        }
        public int GetHashCode(Foo obj)
        {
            // implement GetHashCode for obj
        }
    }
    class Foo
    {
        // fields, properties, methods, etc.
    }
    // a dictionary that can use Foo's as keys
    var myFooDict = new Dictionary<Foo, object>(new FooEqualityComparer())
    {
        // ...
    };
    // use it like normal
    if (myFooDict.ContainsKey(someFoo)) // the comparison will be handled by the comparer provided from the constructor
    {
        // do stuff...
    }
