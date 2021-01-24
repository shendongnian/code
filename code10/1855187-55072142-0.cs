    {
    public class LoginFunction
    {
        public DataTable Login (string username, string pword)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.CnnVal("GymDB")))
            {
                SqlCommand cmd = new SqlCommand("LoginUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@USERNAME", username);
                cmd.Parameters.AddWithValue("@PASSWORD", pword);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                return dtbl;
            }
        }
    }
