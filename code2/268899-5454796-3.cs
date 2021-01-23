    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string sql = "INSERT INTO Customer (Name, SIC_NAIC, Address, City, State, Zip) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = String.Format(sql, 
                TextBox1.Text, 
                RadioButtonList1.SelectedItem.Text, 
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
