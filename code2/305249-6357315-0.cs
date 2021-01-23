    private void button3_Click(object sender, EventArgs e) {
      using (SqlConnection sql = new SqlConnection("server=localhost; uid=xxxx; pwd=xxxx; database=Movies;")) {
        sql.Open();
        using (SqlCommand command = new SqlCommand("insert into [" + folderName + "] values(@P, '')", sql) {
          SqlParameter param = command.Parameters.Add("@P", SqlDbType.VarChar, 50);
          command.Prepare();
          for (int i = 0; i < jointArray.Length; i++) {
            param.Value = jointArray[i].ToString();
            command.ExecuteNonQuery();
          }
        }
      }
    }
