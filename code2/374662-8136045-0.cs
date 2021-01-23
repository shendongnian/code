            using (var con = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(queryStry))
            using (var rs = cmd.ExecuteReader())
            {
                while (rs.Read())
                {
                    //Code.
                }
            }
