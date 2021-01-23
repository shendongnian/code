    Stopwatch sw = Stopwatch.StartNew();
    DataTable dt = null;
    for (int i = 0; i < 100; i++)
    {
        dt = Read1<MySqlConnection>(query); // ~9800ms
        dt = Read2<MySqlConnection, MySqlDataAdapter>(query); // ~2300ms
        dt = Read1<SQLiteConnection>(query); // ~4000ms
        dt = Read2<SQLiteConnection, SQLiteDataAdapter>(query); // ~2000ms
    }
    sw.Stop();
    MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
