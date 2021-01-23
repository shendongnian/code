        dynamic obj = new Dynamitey.DynamicObjects.Dictionary()
        {
            { "foo", "hello" },
            { "bar", 42 },
            { "baz", new object() }
        };
        int value = obj.bar;
