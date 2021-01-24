    class Program
    {
        private class MyClass
        {
            public string ItemId { get; set; }
        }
        static void Main(string[] args)
        {
            var listA = new List<MyClass> {
                new MyClass { ItemId = "a"},
                new MyClass { ItemId = "b"},
                new MyClass { ItemId = "c"},
                new MyClass { ItemId = "d"}};
    
            var listB = new List<MyClass> {
                new MyClass { ItemId = "a"},
                new MyClass { ItemId = "b"},
                new MyClass { ItemId = "x"},
                new MyClass { ItemId = "y"}};
    
            var listWithValidItemsOnly = new List<MyClass>();
    
            foreach (var itemA in listA)
            {
                if (listB.Any(item => item.ItemId == itemA.ItemId))
                    listWithValidItemsOnly.Add(itemA);
            }
    
        }
    }
