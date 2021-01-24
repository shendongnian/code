    var list2 = list.Select(i => int.Parse(i.Replace(':','')));
    var items = (from item in testDB.Items
            where list2.Contains(item.Id,":"))
            .AsEnumerable()   // switch from DB query to memory query
            .Select(item => new
            {
               Hit = string.Concat(item.Id,":"),
               Item = item
            }).ToList();
