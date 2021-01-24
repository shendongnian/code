        public static int InsertProduct(string Inactive, string CategoryId, string Description, string CurrentPrice, string Modified)
        {
            string ConnectionString;
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ToString();
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("_SP_Insert_RefProducts", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Inactive", Inactive=="1"?1:0 ));
            cmd.Parameters.Add(new SqlParameter("@CategoryId", int.Parse(CategoryId)            ));
            Description = Description + "                                                                                             ";
            cmd.Parameters.Add(new SqlParameter("@Description", Description.Substring(0,50)));
            cmd.Parameters.Add(new SqlParameter("@CurrentPrice", double.Parse(CurrentPrice)));
            con.Open();
            int affected;
            affected = cmd.ExecuteNonQuery();
            con.Close();
            return affected;
        }
