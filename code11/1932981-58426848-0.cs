    DataTable dt = new DataTable();
    
    DataColumn column = new DataColumn();
    column.ColumnName = "Switch_FileName";
    dt.Columns.Add(column);
    
    column = new DataColumn();
    column.ColumnName = "Switch_File_Date";
    dt.Columns.Add(column);
    string[] Switch_filePath = Directory.GetFiles(directory, "*.switch", SearchOption.AllDirectories);
    DateTime Switch_L_M_D;
    string S_File_Name;
    foreach (string CurrentPath in Switch_filePath)
    {
       var row = dt.NewRow();
       S_File_Name = Path.GetFileName(CurrentPath);
       Switch_L_M_D = Directory.GetLastWriteTime(CurrentPath);
       row["Switch_FileName"] = S_File_Name;
       row["Switch_File_Date"] = Switch_L_M_D;
       dt.Rows.Add(row);
    }
