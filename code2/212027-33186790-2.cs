    public DataTable getTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("ItemCode", typeof(string)));
        dt.Columns.Add(new DataColumn("Cost", typeof(string)));
        DataRow dr;
        for (int i = 0; i < 10; i++)
        {
            dr = dt.NewRow();
            dr[0] = "ItemCode" + (i + 1);
            dr[1] = "Cost" + (i + 1);
            dt.Rows.Add(dr);
        }
        return dt;
    }
