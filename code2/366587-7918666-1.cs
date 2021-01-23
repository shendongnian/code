    var values = new List<TestClass>
            {
                new TestClass(){Name="John",Comment="Hello"},
                new TestClass(){Name="Smith", Comment="Word"}
            };
    string s = values.ConcatinateString((x => x.Name));
    string v = values.ConcatinateString((x => x.Comment));
