    string connectionString = /* connection string to your database */
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        var command = new SqlCommand("SELECT xmlColumn FROM xmlTable", connection);
        using (var reader = command.ExecuteReader())
        {
            string xml = reader.GetString(0);
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(xml));
            this.GridView1.DataMember = "fruit";
            this.GridView1.DataSource = dataSet;
            this.GridView1.DataBind();
        }
    }
            
