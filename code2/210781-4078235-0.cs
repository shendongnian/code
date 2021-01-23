    var myList = new List<string>() { "A", "B", "C" };
    
    // 1: Modify original list and use List<>.ForEach()
    myList.Insert(0, "S. No");
    myList.ForEach(x => lisView.Columns.Add(x));
    
    // 2: Add first column and use List<>.ForEach()
    listView.Columns.Add("S. No");
    myList.ForEach(x => listView.Columns.Add(x));
    
    // 3: Don't modify original list
    (new[] { "S. No" }).Concat(myList).ToList()
        .ForEach(x => listView.Columns.Add(x));
    
    // 4: Create ColumnHeader[] with Linq and use ListView.Columns.AddRange()
    var columns = (new[] { "S. No"}).Concat(myList)
        .Select(x => new ColumnHeader { Text = x }).ToArray();
    listView.Columns.AddRange(columns);
