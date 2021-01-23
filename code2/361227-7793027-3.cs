    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        cityList.Add(ds.Tables[0].Rows[i][0].ToString());
    }
    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
    {
        cityList.Add(ds1.Tables[0].Rows[i][0].ToString());
    }
