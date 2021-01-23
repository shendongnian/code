    using System;
    public void UseType(Type t) {
        // do something with t using reflection techniques - e.g.
        Console.WriteLine("compat with int? {0}", typeof(int).IsAssignableFrom(t));
    }
