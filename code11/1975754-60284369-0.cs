        private void button2_Click(object sender, EventArgs e)
        {
            string ServerName = textBox1.Text;
            string Database = textBox2.Text;
            string Username = textBox3.Text;
            string Pass = textBox4.Text;
            //string results = textBox5.Text;
            using (var cnn = new SqlConnection($"Data Source= \"{ServerName}\";Initial Catalog= \"{Database}\";User ID=\"{Username}\";Password= \"{Pass}\";"))
            using (var cmd = cnn.CreateCommand())
            {
                cmd.CommandText = "-- Your query here --"; 
                try
                {
                    cnn.Open();
                }
                catch (Exception ex)
                {
                    // Error connecting to db.
                }
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Read your data, row by row, here. ...or do something with textBox5
                        }
                    }
                }
            }
        }
