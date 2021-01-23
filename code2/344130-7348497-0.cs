    var query = (from item in Items.AsEnumerable() .......
    
     DataTable view = new DataTable();
     view.Columns.Add("GroupName");
     view.Columns.Add("ItemName");
     foreach (var t in dvquery)
           {
            view.Rows.Add(t.GName, t.ItemName);
           }
     DataView dv = view.DefaultView;
