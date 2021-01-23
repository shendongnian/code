    string sql = "select * from Users";
    using (SqlConnection conn = GetConnection()){ 
        conn.Open();
        using (SqlDataReader rdr = new SqlCommand(sql, conn).ExecuteReader()){
               foreach (DbDataRecord c in rdr.Cast<DbDataRecord>()){
                   Console.Write("{0} {1} ({2}) - ", (string)c["Name"], (string)c["Surname"], (string)c["Mail"]);
                   Console.WriteLine((string)c["LoginID"]);
              }
        }
    }
