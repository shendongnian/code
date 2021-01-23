    DataTable dt = new DataTable();
    dt.Columns.Add("Id",typeof(int));
    dt.Columns.Add("Item",typeof(string));
    dt.Columns.Add("Price",typeof(decimal));
    dt.AcceptChanges(); // This is the point, where you can change dataTable items.
