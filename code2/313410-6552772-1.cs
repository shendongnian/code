    class Test
    {
        public int Foo { get; set; }
        public string Bar { get; set; }
    }
    static void Main()
    {
        var data = new[] {
            new Test { Foo = 1, Bar = "a"}, new Test { Foo = 1, Bar = "b"},
            new Test { Foo = 2, Bar = "a"}, new Test { Foo = 2, Bar = "b"},
            new Test { Foo = 1, Bar = "a"}, new Test { Foo = 1, Bar = "b"},
            new Test { Foo = 2, Bar = "a"}, new Test { Foo = 2, Bar = "b"},
        };
        var findMe = new Test { Foo = 1, Bar = "b" };
        var found = data.AsQueryable().Where(GetComparer(findMe)).ToList();
        // finds 2 items, as expected
    }
