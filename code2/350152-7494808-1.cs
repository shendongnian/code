    string filePath = Server.MapPath("~/somefile.csv");
    System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
    
    foreach (DataRow r in dt.Rows)
    {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                 sw.Write(r[i].ToString());
                 sw.Write(",");
            }
    
            sw.WriteLine();
    }
    sw.Close();
