    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        // A connection string for testing.
        string connectString = "Server=OracleDemo;Integrated Security=True"
        var builder = new OracleConnectionStringBuilder(connectString);
        // Show your connection string before any change.
        Console.WriteLine("ConnString before: {0}", builder.ConnectionString);
        builder.DataSource = comboBox1.SelectedItem.ToString();
        // This will show your conn string has been updated with the user selected database name.
        Console.WriteLine("ConnString  after: {0}", builder.ConnectionString);
    
        // At this point you're ready to use the updated connection string.
    }
