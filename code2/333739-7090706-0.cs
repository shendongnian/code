    public void OnExportGridToCSV(object sender, System.EventArgs e)
    {
        // Create the CSV file to which grid data will be exported.
        StreamWriter sw = new StreamWriter(Server.MapPath("~/GridData.csv"), false);
        // First we will write the headers.
        DataTable dt = ((DataSet)grid1.DataSource).Tables[0];
 
        int iColCount = dt.Columns.Count;
        for (int i = 0; i < iColCount; i++)
        {
            sw.Write(dt.Columns[i]);
            if (i < iColCount - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        // Now write all the rows.
        foreach (DataRow dr in dt.Rows)
        {
            for (int i = 0; i < iColCount; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    sw.Write(dr[i].ToString());
                }
                if (i < iColCount - 1)
                {
                    sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }
