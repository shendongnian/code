    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < dsResults.Tables[0].Rows.Count - 1; i++)
    {
        sb.Append(PrepareResult(dsResults.Tables[0].Rows[i][0].ToString()));
    }
    litControl.Text = sb.ToString();
    public string PrepareResult(string result)
    {
        return result.Substring(result.IndexOf("<"));
    }
