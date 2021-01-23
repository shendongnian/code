    public MySqlConnection NewConnection(string host, int port, string db, string user, string pwd)
    {
        string cstr = String.Format(
            "SERVER={0};PORT={1};DATABASE={2};UID={3};PWD={4}",
            host, port, db, user, pwdd);
        MySqlConnection conn = new MySqlConnection(cstr);
        try { conn.Open(); }
        catch (Exception ex)
        {
            conn = null;
        }
        return conn;
    }
