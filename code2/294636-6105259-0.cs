    var items = new[]
    {
        new Item { Id = 1, Name = "test1" }, 
        new Item { Id = 2, Name = "test2" }
    };
    var dataTable = new DataTable();
    var propeties = typeof(Item).GetProperties();
    Array.ForEach(propeties, arg => dataTable.Columns.Add(arg.Name, arg.PropertyType));
    Array.ForEach(items, item => dataTable.Rows.Add(propeties.Select(arg => arg.GetValue(item, null)).ToArray()));
    return dataTable;
