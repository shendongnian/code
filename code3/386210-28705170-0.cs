            int rowcount = dataGridViewX1.Rows.Count;
            for (int i = 0; i < rowcount - 1; i++)
            {
                sw.WriteLine(dataGridViewX1.Rows[i].Cells[0].Value.ToString());
            }
            sw.Close();
            MessageBox.Show("txt file created" );
