    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < dtTable.Columns.Count; i++)
    {
        sb.Append(dtTable.Columns[i].ColumnName);
        sb.Append(",");
    }
        
    // Remove the trailing ,
    sb.Remove(sb.Length - 1, 1);
    sb.Append(Environment.NewLine);
    for (int i = 0; i < dtTable.Rows.Count; i++)
    {
        for (int j = 0; i < dtTable.Columns.Count; j++)
        {
            sb.Append(dtTable.Rows[i][j].ToString());
            sb.Append(",");
        }
        sb.Remove(sb.Length - 1, 1);
        sb.Append(Environment.NewLine);
    }
    string csvFileString = sb.ToString();
