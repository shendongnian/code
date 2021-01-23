            using (MySqlConnection oCon = new MySqlConnection("connectionString"))
            {
                string sql = "INSERT INTO table(column) VALUES(@column)";
                MySqlCommand oCom = new MySqlCommand(sql, oCon);
                oCom.Parameters.AddWithValue("@column", "value");
                oCon.Open();
                oCom.ExecuteNonQuery();
                oCon.Close();
            }
