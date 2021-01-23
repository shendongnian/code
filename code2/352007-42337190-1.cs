    using (SqlConnection conn = new SqlConnection("YourConnection") {
        conn.Procedure()
             .AddSqlParameter("@FirstName", SqlDbType.VarChar, txtFirstName.Text)
             .AddSqlParameter("@FirstName", SqlDbType.VarChar, txtLastName.Text)
             .ExecuteNonQuery(conn, "StoreProcedureName");
    }
