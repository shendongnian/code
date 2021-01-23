    DataTable Tb = new DataTable();
    for (int i = 0; i < Tb.Columns.Count; i++)
     {
        for (int j = 0; j < Tb.Rows.Count; j++)
         {
            if (Tb.Rows[j][i].ToString().IndexOf(',') != -1)
            {
                Tb.Rows[j][i] = "\"" + Tb.Rows[j][i].ToString() + "\"";
            }
         }
     } 
                                 
