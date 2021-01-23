    System.Data.DataTable table = new System.Data.DataTable();
    table.Columns.Add("", typeof(Boolean));
    table.Columns[0].Expression = "true and false or true";
    
    System.Data.DataRow r = table.NewRow();
    table.Rows.Add(r);
    Boolean result = (Boolean)r[0];
