    MyClass[] classes = 
    {
        new MyClass() { Created = DateTime.Now.AddDays(12)},
        new MyClass() { Created = DateTime.Now.AddDays(-5), Updated = DateTime.Now.AddDays(3)},
        new MyClass() { Created = DateTime.Now},
        new MyClass() { Created = DateTime.Now.AddDays(2), Updated = DateTime.Now.AddDays(10)},
        new MyClass() { Created = DateTime.Now},
        new MyClass() { Created = DateTime.Now.AddDays(1), Updated = DateTime.Now.AddDays(1)},
        new MyClass() { Created = DateTime.Now},
        new MyClass() { Created = DateTime.Now.AddDays(20), Updated = DateTime.Now.AddDays(4)}
    };
