     try {
         using ( SqlConnection conn = new SqlConnection(cstr)) {
           SqlParameter name = cmd.Parameters.Add( "@name", SqlDbType.NVarChar, 15 );
           name.Value = TextBox1.Text;
           string insertString = @"insert into Table(columnName) values (@name)";
    
           SqlCommand cmd = new SqlCommand(insertString, conn);
           cmd.ExecuteNonQuery();
         }
    } catch (Exception ex) {
      //do some logging
    } finally {
      conn.Close();
    }
