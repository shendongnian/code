    var x =
        // First, combine all lists
        food.Concat(drinks).Concat(magazines)
        // Group combined Items by Id
        .GroupBy(item => item.Id)
        // From all groups create final Items with Id and summed Price
        .Select(g => new Item { Id = g.Key, Price = g.Sum(item => item.Price) });
