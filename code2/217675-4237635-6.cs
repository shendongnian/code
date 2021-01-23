    List<MyObject> newList = new List<MyObject>();
    foreach (var grp in list.GroupBy(x => new { x.City, x.ID }))
    {
        MyObject prev = null;
        foreach (var obj in grp.OrderBy(y => y.Date))
        {
            newList.Add(new MyObject
            {
                ID = obj.ID,
                City = obj.City,
                Date = obj.Date,
                Value = obj.Value,
                DiffToPrev = (prev == null) ? obj.Value : obj.Value - prev.Value
            });
            prev = obj;
        }
    }
