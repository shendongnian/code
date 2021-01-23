    for (int cIdx = 0; cIdx < ds.Tables[0].Columns.Count; ++cIdx) {
        int tIdx = cIdx + 1;
        if (tIdx >= ds.Tables.Count) {
            break;
        }
        ds.Tables[tIdx].TableName = ds.Tables[0].Rows[0][cIdx].ToString().Trim();
    }
    ds.Tables.RemoveAt[0];
