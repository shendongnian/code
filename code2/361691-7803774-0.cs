    internal class Program
    {
        private static void Main(string[] args)
        {
            TestItemCollection items = new TestItemCollection();
            items.Add(new TestItem("a"));
            items.Add(new TestItem("a")); // throws ArgumentException -- duplicate key
            TestItem a = items["a"];
            a = items[0];
        }
        private sealed class TestItem
        {
            public TestItem(string value)
            {
                this.Value = value;
            }
            public string Value { get; private set; }
        }
        private sealed class TestItemCollection : KeyedCollection<string, TestItem>
        {
            public TestItemCollection()
            {
            }
            protected override string GetKeyForItem(TestItem item)
            {
                return item.Value;
            }
        }
    }
