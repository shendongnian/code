            string connString = "{Connection string here}";
            string sql = "{SQL Query Here}";
            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    int numRows = cmd.ExecuteNonQuery();
                }
            }
