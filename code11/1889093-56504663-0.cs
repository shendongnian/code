        var categories = new List<Category>() {
            new Category() { sequence = 3, categoryName = "Category F" },
            new Category() { sequence = 1, categoryName = "Category S" },
            new Category() { sequence = 2, categoryName = "Category Z" },
            new Category() { sequence = 4, categoryName = "Category X" },
            new Category() { sequence = 5, categoryName = "Category V" }
        };
        List<string> list = new List<string>();
        for (int i = 0; i < 6; i++)
        {
            list.Add("");
        }
        
        foreach (var item in categories)
        {
            list[item.sequence] = item.categoryName;
        }
        var removeFrom = 2;
        var removeTo = 5;
        list.Insert(removeTo, list[removeFrom]);
        list.RemoveAt(removeFrom);
