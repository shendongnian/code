    List<string> services = new List<string>();
    for (int i = 0; i < chkservices.Items.Count; i++)
    {
        if (chkservices.Items[i].Selected == true)
        {
            services.Add(chkservices.Items[i].Text);
        }
    }
    
    //...connection stuff....
    strSQL = "INSERT INTO MyTable (MyField) VALUES (@val)"
    using (SqlCommand command = new SqlCommand(strSQL, connection))
    {
        command.Parameters.AddWithValue("@val", "");
        foreach (string service in services)
        {
            command.Parameters["@val"].Value = service;
            command.ExecuteNonQuery();
        }
    }
