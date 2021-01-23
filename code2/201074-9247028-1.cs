     DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[]
    { null,null, sheetName, null });
     List<string> listColumn = new List<string>();
     foreach (DataRow row in dt.Rows)
     {
          listColumn.Add(row["Column_name"].ToString());
     }
