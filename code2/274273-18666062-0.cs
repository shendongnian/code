    MyTestClass[] items = new MyTestClass[3];
    items[0] = new MyTestClass { ValueA = 1, ValueB = 1 };
    items[1] = new MyTestClass { ValueA = 0, ValueB = 1 };
    items[2] = new MyTestClass { ValueA = 1, ValueB = 1 };
    MyTestClass [] distinctItems = items.DistinctBy(p => new {p.ValueA, p.ValueB}).ToArray();
    MyTestClass [] duplicates = items.Except(distinctItems).ToArray();
