    class TestObj
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }
    }
    var hierarchicalCollection = new List<TestObj>();
    hierarchicalCollection.Add(new TestObj() 
        {Items = new List<string>()
            {"testObj1-Item1", "testObj1-Item2"}, Name="t1"});
    hierarchicalCollection.Add(new TestObj() 
        {Items = new List<string>()
            {"testObj2-Item1", "testObj2-Item2"}, Name="t2"});
