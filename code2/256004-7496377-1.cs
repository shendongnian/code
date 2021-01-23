    for (int rIdx = 0; rIdx < ds.Tables[0].Rows.Count; ++rIdx) {
        int tIdx = rIdx + 1;
        if (tIdx >= ds.Tables.Count) {
            break;
        }
        ds.Tables[tIdx].TableName = ds.Tables[0].Rows[0][0].ToString().Trim();
    }
