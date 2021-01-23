    internal static bool WriteTransaction(string command) {
        try {
            using (SqlConnection conn = new SqlConnection(SqlConnectionString)) {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(command, conn)) {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch { 
            return false; 
        }
        return true;
    }
