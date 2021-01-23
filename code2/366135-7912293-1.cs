    string name = "First Name";// Column name supposed to hide
    int index=-1;
    foreach (DataColumn col in gvEmployees.Columns)
    {
     if (col.ColumnName.ToLower().Trim() == name.ToLower().Trim())
     {
      col.Visible = false;
     }
    
    }
