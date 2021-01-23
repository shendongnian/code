        public void BackUpDB(string fname)
        {
            using (SqlConnection cn = new SqlConnection(_cstr))
            {
                cn.Open();
                string cmd = "BACKUP DATABASE [Stats] TO DISK='" + fname + "'";
                using (var command = new SqlCommand(cmd, cn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void RestoreDB(string fname)
        {
            using (SqlConnection cn = new SqlConnection(_cstr))
            {
                cn.Open();
                #region step 1 SET SINGLE_USER WITH ROLLBACK
                string sql = "IF DB_ID('Stats') IS NOT NULL ALTER DATABASE [Stats] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
                #region step 2 InstanceDefaultDataPath
                sql = "SELECT ServerProperty(N'InstanceDefaultDataPath') AS default_file";
                string default_file = "NONE";
                using (var command = new SqlCommand(sql, cn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                       if (reader.Read())
                        {
                            default_file = reader.GetString(reader.GetOrdinal("default_file"));
                        }
                    }
                }
                sql = "SELECT ServerProperty(N'InstanceDefaultLogPath') AS default_log";
                string default_log = "NONE";
                using (var command = new SqlCommand(sql, cn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            default_log = reader.GetString(reader.GetOrdinal("default_log"));
                        }
                    }
                }
                #endregion
                #region step 3 Restore
                sql = "USE MASTER RESTORE DATABASE [Stats] FROM DISK='" + fname + "' WITH  FILE = 1, MOVE N'Stats' TO '" + default_file + "Stats.mdf', MOVE N'Stats_Log' TO '"+ default_log+ "Stats_Log.ldf', NOUNLOAD,  REPLACE,  STATS = 1;";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
                #region step 4 SET MULTI_USER
                sql = "ALTER DATABASE [Stats] SET MULTI_USER";
                using (var command = new SqlCommand(sql, cn))
                {
                    command.ExecuteNonQuery();
                }
                #endregion
            }
        }
