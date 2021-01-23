        private void Form1_Load(object sender, EventArgs e)
        {
            Timer t = new Timer();
            t.Interval = 500;
            t.Enabled = false;
            dataGridView1.CellMouseEnter += (a, b) =>
            {
                if (b.RowIndex != -1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[b.RowIndex].Cells[0];
                    dataGridView1.Rows[b.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    dataGridView1.Rows[b.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                    t.Tick += (c, d) =>
                    {
                        dataGridView1.Rows[b.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Blue;
                        dataGridView1.Rows[b.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
                        t.Enabled = false;
                    };
                    t.Enabled = true;
                }
            };
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns.Add("Col1", "Col1");
            dataGridView1.Columns.Add("Col2", "Col2");
            dataGridView1.Rows.Add("Row1", "Col1");
            dataGridView1.Rows.Add("Row1", "Col2");
            dataGridView1.Rows.Add("Row2", "Col1");
            dataGridView1.Rows.Add("Row2", "Col2");
            dataGridView1.Rows.Add("Row3", "Col1");
            dataGridView1.Rows.Add("Row3", "Col2");
            dataGridView1.Rows.Add("Row4", "Col1");
            dataGridView1.Rows.Add("Row4", "Col2");
        }
