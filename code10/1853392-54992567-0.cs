           for (int i = 0; i < dataGridView1.Rows.Count; i++)
           {
               command.Parameters["@Name"].Value = dataGridView1.Rows[i].Cells[0].Value;
               command.Parameters["@Age"].Value = dataGridView1.Rows[i].Cells[1].ValueType;
               command.ExecuteNonQuery();
           }
           connection.Close();
           dataGridView1.Rows.Clear();
