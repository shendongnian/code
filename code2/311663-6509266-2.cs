            SqlConnection conn = (SqlConnection) dba.Connection;
            using(SqlCommand cmd = new SqlCommand(queryUpdate, conn))
            {
                rowsreturned = cmd.ExecuteNonQuery();
            }
