    string someValue = "";
    if (ds != null &&
        ds.Tables != null &&
        ds.Tables.Any() &&
        ds.Tables[0].Rows != null &&
        ds.Tables[0].Rows.Any() &&
        ds.Tables[0].Rows[0]["col1"] != DBNull.Value)
    {
        someValue = ds.Tables[0].Rows[0]["col1"];
    }
