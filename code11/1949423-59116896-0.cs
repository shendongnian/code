    var list1 = new List<string>
            {
                "Product 1",
                "Product 2",
                "Product 3",
                "Product 4"
            };
    var list2 = new List<string>
            {
                "Product 2",
            };
    var list3 = list1.Where(i => list2.All(x => x != i)).ToList();
    var list4 = list1.Except(list2).ToList();
