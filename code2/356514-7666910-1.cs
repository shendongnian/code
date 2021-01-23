            /// <summary>
        /// Supply our own connection string to the DBContext to utilize mini-profiler for SQL queries as well.
        /// </summary>
        /// <returns>DBConnection</returns>
        private static DbConnection GetProfilerConnection()
        {
            return new EFProfiledDbConnection(new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString),
                                            MiniProfiler.Current);
        }
