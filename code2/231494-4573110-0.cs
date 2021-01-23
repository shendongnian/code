    // grouping the first of each items' Routes
    var query1 = from itemList in myItemListList
                 where statusList.Contains(itemList.Status)
                     && itemList.Routes.Any() // only add items with at least 1 route
                 group itemList.Routes.First() by itemList.ItemID into g
                 select new
                 {
                     ItemID = g.Key,
                     Routes = g.AsEnumerable()
                 };
    // grouping with all of each items' Routes (flattening)
    var query2 = from itemList in myItemListList
                 where statusList.Contains(itemList.Status)
                 group itemList.Routes by itemList.ItemID into g
                 select new
                 {
                     ItemID = g.Key,
                     Routes = g.SelectMany(routes => routes),
                 };
