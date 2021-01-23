    // Code snippet to hide columns from a gridview named 'gvEmployees'
    gvEmployees.DataSource = dvItems.ToTable();
    gvEmployees.DataBind();
    string name = "First Name";// Column name supposed to hide
    foreach (var col in gvEmployees.Columns)
    {
     if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
     {
      // hiding the column from the grid view.
      col.Visible = false;
     }
     
    }
