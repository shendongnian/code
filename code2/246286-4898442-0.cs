    DataTable dt = new DataTable();
    string output;
    for (int i = 0; i < dt.Rows.Count; i++)
    {
        output = output + dt.Rows[i]["ID"].ToString();
        output += (i < dt.Rows.Count) ? "," : string.Empty;
    }
