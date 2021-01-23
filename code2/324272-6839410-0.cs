    DataTable Tb = new DataTable();
    for (int i = 0; i < Tb.Columns.Count; i++)
     {
        for (int j = 0; j < Tb.Rows.Count; j++)
         {
           if (Tb.Rows[j][i].ToString() == "you,me")
            {
                Tb.Rows[j][i] = "\"you,me\"";
            }
         }
     } 
                                 
