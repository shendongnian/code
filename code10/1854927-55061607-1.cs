    for (int i = 1; i < dt.Rows.Count; i++)
    {
        if (dt.Rows[i][0].ToString() != dt.Rows[i - 1][0].ToString())
        {
            DataRow row = dt.NewRow();
            object[] oArray = new object[] { ""};
            row.ItemArray = oArray;
            dt.Rows.InsertAt(row, i);
            i++;
        }
    }
