    public static DataTable listUsers()
            {
                string sqlCommand = "SELECT name, senha FROM users";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(new NpgsqlCommand(sqlCommand, Connect()));
    
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
