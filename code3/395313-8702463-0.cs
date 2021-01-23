    public  int Studentid() {
      try {
        using (SqlConnection con = new SqlConnection(connectionStr)) {
          using (SqlCommand cmd = new SqlCommand("SELECT s_id FROM student where name = (@Name)", con)) {
            cmd.Parameters.Add("@Name", DbType.VarChar, 50).Value = Request.QueryString.ToString();
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader()) {
              if (dr.Read()) {
                return dr.GetInt32(0);
              } else {
                return -1; // some value to indicate a missing record
                // or throw an exception
              }
            }
          }
        }
      } catch (Exception ex) {
        throw; // just as this, to rethrow with the stack trace intact
      }
    }
