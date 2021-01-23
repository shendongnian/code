    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < dsResults.Tables[0].Rows.Count - 1; i++)
    {
        sb.Append(dsResults.Tables[0].Rows[i][0].ToString());
    }
    litControl.Text = sb.ToString();
