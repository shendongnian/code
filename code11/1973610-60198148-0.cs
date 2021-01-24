    //List of tables
    var tableList = new string[] { "Table1", "Table2" }; 
    
    var r = db.Table1
            .GroupBy(t1 => "Table1")
            .Select(gt1 => new { Name = gt1.Key, EntryCount = gt1.Count()})
            .Union(db.Table2
                   .GroupBy(t2 => "Table2")
                   .Select(gt2 => new { Name = gt2.Key, EntryCount = gt2.Count()})
                   )
            .Union(tableList
                   .GroupBy(s => s)
                   .Select(gs => new { Name = gs.Key, EntryCount = 0 })
                   )
            .GroupBy(gg => gg.Name)
            .Select(fg => new { Name = fg.Key, EntryCount = fg.Select(ee => ee.EntryCount).Sum()})
            .ToList();
