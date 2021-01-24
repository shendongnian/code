    internal string GetSexDescription(string sex, int id_merchant)
    {
        string newSex = "";
        var builder = new ConnectionStringHelper();
        var connString = builder.getCasinoDBString(id_merchant);
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string sql = "SELECT Description FROM person_gender_lookup WHERE ID" +  sex;;
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
             
                newSex = cmd.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newSex;
        }
    }
