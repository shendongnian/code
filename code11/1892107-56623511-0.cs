    Foo MapDictionaryToFoo(IReadOnlyDictionary<string, dynamic> d)
    {
        return new Foo
        {
            ID1 = d[nameof(Foo.ID1)],
            ID2 = d[nameof(Foo.ID2)],
            ID3 = d[nameof(Foo.ID3)]
        };
    }
