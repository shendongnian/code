    // check if the table and row exists
    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    {
        string j = ds.Tables[0].Rows[0].ToString();
        int value = 0;
        if (int.TryParse(j, out value))
            txtbankid.Text = value.ToString();
    }
