    var x =
        // First, combine all lists
        food.Concat(drinks).Concat(magazines)
        // Group combined Items by Id
        .GroupBy(g => g.Id)
        // From all groups create final Items with Id and summed Price
        .Select(g => new Item { Id = g.Key, Price = g.Sum(item => item.Price) });
