        private void button3_Click(object sender, EventArgs e)
        {
            DataTable destiny = new DataTable();
            destiny.Columns.Add("c1");
            destiny.Columns.Add("c2");
            destiny.Columns.Add("c3");
            destiny.Columns.Add("c4");
            CopyColumns(dtST_Split, destiny, "c1", "c2","c3","c4");
        }
        private void CopyColumns(DataTable source, DataTable dest, params string[] columns)
        {
            foreach (DataRow sourcerow in source.Rows)
            {
                DataRow destRow = dest.NewRow();
                foreach (string colname in columns)
                {
                    destRow[colname] = sourcerow[colname];
                }
                dest.Rows.Add(destRow);
            }
        }
