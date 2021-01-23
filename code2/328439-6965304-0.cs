     DataTable Table = new DataTable();
        DataRow row;
        try
        {
    //Add column here
            row = Value.NewRow();
            for (int i = 0; i < Value.Rows.Count; i++)
            {
                TableNm = new DataView(DB.Tables[1]);
                TableNm.RowFilter = "name = " + "'" +""+Value.Rows[i][0].ToString()+"" + "'" + "";
                row[i] = (TableNm.ToTable()).Rows;
            }
            Table.Rows.Add(row.ItemArray);
