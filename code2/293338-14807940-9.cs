    Stopwatch sw = Stopwatch.StartNew();
    DataTable dt = null;
    for (int i = 0; i < 100; i++)
    {
        dt = Read1<MySqlConnection>(query); // ~9800ms
        dt = Read2<MySqlConnection, MySqlDataAdapter>(query); // ~2300ms
        dt = Read1<SQLiteConnection>(query); // ~4000ms
        dt = Read2<SQLiteConnection, SQLiteDataAdapter>(query); // ~2000ms
        dt = Read1<SqlCeConnection>(query); // ~5700ms
        dt = Read2<SqlCeConnection, SqlCeDataAdapter>(query); // ~5700ms
        dt = Read1<SqlConnection>(query); // ~850ms
        dt = Read2<SqlConnection, SqlDataAdapter>(query); // ~600ms
        dt = Read1<VistaDBConnection>(query); // ~3900ms
        dt = Read2<VistaDBConnection, VistaDBDataAdapter>(query); // ~3700ms
    }
    sw.Stop();
    MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
