    string name = "First Name";// Column name supposed to hide
    int index=-1;
    foreach (DataColumn col in gvEmployees.Columns)
    {
     if (col.ColumnName.ToLower().Trim() == name.ToLower().Trim())
     {
      // Getting the column index if find a match
      index= gvEmployees.Columns.IndexOf(col); 
      // Using the above index, hiding the column from the grid view.
      gvEmployees.Columns[index].Visible = false;
     }
    
    }
