     OracleConnectionStringBuilder builder =
                    new OracleConnectionStringBuilder("");//put connection string here
        builder.InitialCatalog = (string)comboBox1.SelectedItem;
        OracleConnection conn = new OracleConnection(builder.ConnectionString);
        OracleCommand cmd = new OracleCommand("Select 1 from dual", conn);
        conn.Open();
        int temp = cmd.ExecuteScalar();
        conn.Close();
