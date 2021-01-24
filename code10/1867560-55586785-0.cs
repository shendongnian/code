    foreach (var id in itemIds)
    {
        if (itemIds.Any(x=> x.Code == item.Code && x.Name == item.Name && x.Price == item.Price))
        {
            var display = DisplayList.Single(x=> x.Code == item.Code && x.Name == item.Name && x.Price == item.Price);
            display.IdSubs.Add(id);//change IdSub to IdSub, as a list of its previous type
        }
        else
        {
            Display display = new Display();
            display.Code = item.Code;
            display.Name = item.Name;
            display.Price = item.Price;
            display.IdSubs = new List<int>();//Assumed that IdSub was int
            DisplayList.Add(display);
        }
    }
