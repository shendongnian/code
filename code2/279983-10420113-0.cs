    for (int i = 0; i < _Count; i++)
    {
        TestClass tClass = new TestClass();
        tClass.Description = "TestClass" + i.ToString();
        Columns.Add(tClass);
        this.Container.Add(tClass);   // <-- added
    }
