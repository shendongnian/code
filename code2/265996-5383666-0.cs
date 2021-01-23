    //List<Item> items = new List<Item>();
    //items.Add(item1);
    //items.Add(item2);
    //items.Add(item3);
    var groupedBySub = from item in items
                       from s in item.Subs
                       group item by s into g
                       select new{ Sug = g.Key, Items = g };
   
