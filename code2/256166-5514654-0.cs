    public MySqlConnection NewConnection()
    {
        string cstr = String.Format(
            "SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4}",
            sett.DBHost, sett.DBPort, sett.DBDatabase,
            HotelDB.user, HotelDB.password);
        MySqlConnection conn = new MySqlConnection(cstr);
        try { conn.Open(); }
        catch (Exception ex)
        {
            conn = null;
        }
        return conn;
    }
    private MySqlCommand NewCommand(MySqlConnection conn, string cmd, params object[] parameters)
    {
        if (conn==null) return null;
        MySqlCommand command;
        try
        {
            command = new MySqlCommand(cmd, conn);
            if (parameters != null)
            {
                int index = 0;
                while (index < parameters.Length)
                {
                    command.Parameters.Add(
                        new MySqlParameter((string)parameters[index], parameters[index + 1]));
                    index += 2;
                }
            }
        }
        catch { command = null; }
        return command;
    }
    private string MD5(string Value)
    {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i=0; i < data.Length; i++)
                    ret += data[i].ToString("x2").ToLower();
            return ret;
    }
