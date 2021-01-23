    using (SqlConnection conn = new SqlConnection(strconString)){
       string cmdstr = "select status from racpw where vtgid = " + vtgid;
       using (SqlCommand cmdselect = new SqlCommand(cmdstr, conn)){
         conn.Open();
         using(SqlDataReader dtr = cmdselect.ExecuteReader()){
           if (dtr.Read())
           {
              return;
           }
           else
           {
             ...
            }
         }
       }
    }
