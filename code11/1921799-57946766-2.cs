        private void Button1_Click(object sender, EventArgs e)
        {
            string[] arr = { "BB", "Bb", "bB", "bb" };
            int numberOfColumns = 4;
            int numberOfRows = 4;
            dataGridView1.Columns.Add("aa", "aa");
            dataGridView1.Columns.Add("AA", "AA");
            dataGridView1.Columns.Add("Aa", "Aa");
            dataGridView1.Columns.Add("aA", "aA");
            dataGridView1.Rows.Add(numberOfRows);
            for (int i = 0; i < numberOfColumns; i++)
            {
                dataGridView1[i, 0].Value = arr[i];
            }
        }
