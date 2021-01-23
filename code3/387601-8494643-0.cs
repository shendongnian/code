    using (var conn = new SqlConnection(strconString))
    {
        string cmdstr = "SELECT ID, FirstName, LastName FROM dbo.Employee"
        using (var cmdselect = new SqlCommand(cmdstr, conn))
        {
            conn.Open();
            using(var dtr = cmdselect.ExecuteReader())
            {
               while (rdr.Read())
               {
                  // here you use the values from the DataReader...
               }
            }
        }
    }
