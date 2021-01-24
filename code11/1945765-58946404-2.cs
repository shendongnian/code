    string sql = "insert into Member(col1, col2, col3) values(@val1, @val2, @val3)";
    using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cvyc8\Documents\Testing.mdf;Integrated Security=True;Connect Timeout=30"))
    {
      connection.Open();
      using (SqlCommand cmd= new SqlCommand(sql, connection))
      {
         md.Parameters.Add("@val1", SqlDbType.Varchar, 50).value = txtFirstName.Text;  
         cmd.Parameters.Add("@val2", SqlDbType.Varchar, 50).value =  txtLastName.Text;
         cmd.Parameters.Add("@val3", SqlDbType.Varchar, 50).value = txtAddress.Text;
         cmd.ExecuteNonQuery();
      }
         MessageBox.Show("Member added successfully");
    }
