            int numberOfRowsAffected = 0;
            bool isDeleted = false;
            string query = @"DELETE FROM targetTable WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@ID", deletedItemID));
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    object result = cmd.ExecuteNonQuery();
                    isDeleted = Convert.ToInt32(result) > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                isDeleted = false;
            }
