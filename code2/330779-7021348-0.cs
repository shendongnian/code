    StringBuilder sw = new StringBuilder();
    //assuming you have a datatable named dt
    int NumColumns = dt.Columns.Count;
        for (int i = 0; i < NumColumns; i++)
        {
            sw.Write(dt.Columns[i]);
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        // write = the rows.
        foreach (DataRow dr in dt.Rows)
       {
            for (int i = 0; i < NumColumns; i++)
            {
                sw.Write(dr[i].ToString());
                if (i < NumColumns - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        
  
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=file.csv");
        Response.ContentType = "text/csv";
        Response.AddHeader("Pragma", "public");
        Response.Write(sw.ToString());
        Response.Write(sw.NewLine);
        Response.End();
