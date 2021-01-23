    DataTable dt = new DataTable();    
        for (int j = 0; j < datagridview1.Rows.Count; j++)
        {
            DataRow dr;
            GridViewRow row = datagridview1.Rows[j];
            dr = dt.NewRow();
            for (int i = 0; i < row.Cells.Count; i++)
            {
                dr[i] = row.Cells[i].Text;
            }
    
            dt.Rows.Add(dr);
        }
