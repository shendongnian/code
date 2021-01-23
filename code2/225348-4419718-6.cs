    static IEnumerable<Product> SomeMethod(IEnumerable<Product> products) {
        foreach(p in products) {
            p.Foo = ...
            p.Bar = ...
            yield return p;
        }
    }
