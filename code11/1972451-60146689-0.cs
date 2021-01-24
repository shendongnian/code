    public static SqlCommand CreateCommand(this SqlConnection conn, string cmdText, SqlTransaction tran = null)
            => new SqlCommand(cmdText, conn, tran) { CommandTimeout = 3000 };
        [STAThread]
        static void Main()
        {
            var conn = new SqlConnection("xyz");
            var cmd = conn.CreateCommand("select 1");
        }
