    var sb = new StringBuilder();
  
    foreach (DataRow row in tbl.Rows)
    {
        sb.AppendLine(string.Format("{0}, {1} {2}",
                                    row[0].ToString(),
                                    row[1].ToString(),
                                    row[2].ToString()));
    }
    txtBox1.Text = sb.ToString();
