    private void buttonaddcompany_Click(object sender, EventArgs e)
    {
        string MyConString = "SERVER=localhost;" + "DATABASE=payroll;" + "UID=root;" + "PASSWORD=admin;";
        MySqlConnection connection = new MySqlConnection(MyConString);
        MySqlCommand command = connection.CreateCommand();
        command.Connection = connection;
        using (MySqlConnection conn = new MySqlConnection(MyConString))
        {
            connection.Open();
            using (MySqlCommand com = connection.CreateCommand())
            {
                command.CommandText = "insert into company(company_name, /* other fields here , */ company_country_zipcode) values(?company_name, 'company_other_names', /* other hardcoded fields here , */ 'company_country_zipcode')";
                command.Parameters.Add(new MySqlParameter("?company_name", SqlDbType.VarChar));
                command.Parameters["?company_name"].Value = addcompname.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                command.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
            }
        }
    }
