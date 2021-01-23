        public static void Initialize()
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["membership"].ConnectionString);
            if (!MembershipExists(connection))
            {
                // create schema
                string regsql = Path.Combine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory(), "aspnet_regsql.exe");
                string args = string.Format(@"-E -S {0} -A all -d {1}", connection.DataSource, connection.Database);
                var proc = Process.Start(regsql, args);
                if (proc != null)
                    proc.WaitForExit();
            }
        }
        public static bool MembershipExists(SqlConnection connection)
        {
            try
            {
                connection.Open();
                var query = new SqlCommand("select count(*) from sysobjects where name = 'aspnet_CheckSchemaVersion' and type = 'P'", connection);
                return query.ExecuteScalar() as int? == 1;
            }
            finally
            {
                connection.Close();
            }
        }
