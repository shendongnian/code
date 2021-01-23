    protected void Button1_Click(object sender, EventArgs e)
    {
        String connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\aspnetdb.mdf;Integrated Security=True;User Instance=True";
        string sql = "INSERT INTO Customer (Name, SIC_NAIC, Address, City, State, Zip) VALUES ('{}', '{}', '{}', '{}', '{}', '{}')";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = String.Format(sql, 
                TextBox1.Text, 
                RadioButtonList1.SelecedItem.Text, 
                TextBox2.Text, 
                DropDownList1.SelectedItem.Text, 
                TextBox3.Text, 
                "000000");
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
