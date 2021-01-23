            // create array big enough for all the rows and columns in the grid
            string[,] LogArray = new string[dataGridView1.Rows.Count, dataGridView1.Columns.Count];
            int i = 0;
            int x = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                while (x < dataGridView1.Columns.Count)
                {
                    LogArray[i, x] = row.Cells[x].Value != null ? row.Cells[x].Value.ToString() : string.Empty;
                    x++;
                }
                x = 0;
                i++; //next row
            }
