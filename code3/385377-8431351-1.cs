    item1 = new Category{Id = 1, Name = "Computers"};
    item2 = new Category{Id = 2, Name = "Laptops", Parent = item1};
    item3 = new Category{Id = 3, Name = "Acer", Parent = item2};
    Debug.Print(item3.ToString());
    Debug.Print(item2.ToString());
    Debug.Print(item1.ToString());
