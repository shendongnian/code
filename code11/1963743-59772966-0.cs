        public DataSet Select(string command)
        {
            string connString = LoadConnectionString();
            DataSet dataSet = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter())
                {
                    Console.WriteLine(conn.State);
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    cmd.CommandTimeout = 120;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataSet);
                }
                conn.Close();
            }
            return dataSet;
        }
