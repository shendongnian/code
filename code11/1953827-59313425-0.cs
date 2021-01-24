            using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
            {
                IEnumerable<int> ids = bunifuCustomDataGrid1
                    .Rows[bunifuCustomDataGrid1.CurrentRow.Index]
                    .Cells
                    .Select(x => Convert.ToInt32(x.Value));
                string sql = $"DELETE FROM bookdb.book WHERE BookID IN ({string.Join(", ", ids)})";
                mysqlCon.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mysqlCon);
                cmd.ExecuteNonQuery();
                mysqlCon.Close();
                GridFill();
            }
            MessageBox.Show("DOne");
