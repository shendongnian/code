    public static DataTable UpdateRoutine(SQLConnection c, string value) {
      const string w = "insert into checkmultiuser(username) values (@username)";
      DataTable table = new DataTable();
      using(SQLCommand cmd = new SQLCommand(w, c)) {
        cmd.Parameters.Add("@username", SqlDbType.VarChar);
        cmd.Parameters["@username"].Value = value;
        try {
          if ((cmd.Connection.State & ConnectionState.Open) != ConnectionState.Open) {
            cmd.Connection.Open();
          }
          using (SqlDataReader r = cmd.ExecuteReader()) {
            table.Load(r);
          }
        }
        return table;
      } catch(SqlException err) { // I try to avoid catching a general exception.
        MessageBox.Show(err.Message, "SQL Error");
      }
      return null;
    }
