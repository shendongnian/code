    DataColumn dc = new DataColumn("Amount1");
    local_ds.Tables[0].Columns.Add(dc);
    
    for (int i = 0; i < AchDB.Amount1.Count; i++)
    {
        local_ds.Tables[0].Rows[i]["Amount1"] = AchDB.Amount1[i];
    }
