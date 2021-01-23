    using (MySqlConnection connection = new MySqlConnection(MyConString)) {
      using (MySqlCommand command = connection.CreateCommand()) {
        command.CommandText = "select count(*) from " + datatable + " where code = @Code";
        command.Parameters.Add("@Code", dbType.VarChar, 50).Value = textBox1.Text;
        connection.Open();
        if ((int)(command.ExecuteScalar()) > 0) {
          already = 1;
        }
      }
    }
