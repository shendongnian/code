        string updatefilePath = Server.MapPath("Files\\newoutput.PIPE");
        StreamWriter sw = new StreamWriter(updatefilePath, false);
        int iColCount = dt.Columns.Count;
        for (int i = 0; i < iColCount; i++)
        {
            sw.Write(dt.Columns[i]);
            if (i < iColCount - 1)
            {
                sw.Write("|");
            }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < iColCount; i++)
            {
                if (!Convert.IsDBNull(row[i]))
                {
                    sw.Write(row[i].ToString());
                }
                if (i < iColCount - 1)
                {
                    sw.Write("|");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
