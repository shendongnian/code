    var a = listA.ToDictionary(k => k.Id, v => v.Price);
    foreach(var item in listB)
    {
        item.Price = a.TryGetValue(item.Id, out var newPrice) ? newPrice : item.Price;
    }
