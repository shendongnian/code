    var orderedList = GetSomeData()
        .OrderBy(x => x.Cat1)
        .ThenBy(x => x.Cat2)
        .ThenBy(x => x.Price);
    var result = orderedList.Select((e, i) =>
    {
        e.Price = e.Price ?? GetPrice(i);
        return e;
    });
    double GetPrice(int index)
    {
        return orderedList.ElementAt(++index).Price
               ?? GetPrice(index);
    }
