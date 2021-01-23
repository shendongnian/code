    StringBuilder sb = new StringBuilder(1024);
    string sql = "Select * From Events";
    SqlCommand command = new SqlCommand(sql, conn);
    command.CommandType = CommandType.Text;
    conn.Open();
    reader = command.ExecuteReader();
    while (reader.Read())
    {
        sb.AppendLine("Name: " + reader["Name"].ToString() + "<br />" +
            "Date: " + reader["Date"].ToString() + "<br />" +
            "Location: " + reader["Location"].ToString() + "<br />");
    }
    
    if(sb.Length > 0) {
        divout.InnerHtml = sb.ToString();
        divout.Visible = true;
    }
