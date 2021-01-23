            ThreadPool.QueueUserWorkItem(() => GetSqlData());
        }
        private object GetSqlData()
        {
            using (var connection = new SqlCeConnection("ConnectionString"))
            {
                using(var command = new SqlCeCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM tbl_hello";
                    command.ExecuteReader();
                    while (command.ExecuteReader().Read())
                    {
                        // put data somewhere
                    }
                }
            }
        }
