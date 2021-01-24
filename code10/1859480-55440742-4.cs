        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = new[] { 
                new {Title = "bella", Date1 = DateTime.Now.AddDays(1)}, 
                new {Title = "ciao", Date1 = DateTime.Now.AddDays(12)}, 
                new {Title = "bella", Date1 = DateTime.Now.AddDays(-1)}, 
                new {Title = "ciao", Date1 = DateTime.Now.AddDays(-31)}, 
                new {Title = "bella", Date1 = DateTime.Now.AddDays(11)}, 
                new { Title= "ciao", Date1 = DateTime.Today} ,
                new { Title= "ciao", Date1 = DateTime.Today} ,
                new { Title= "ciao", Date1 = DateTime.Today.AddDays(-7)} };
            
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Date1")
            {
                var date = dataGridView1.Rows[e.RowIndex].Cells["Date1"].Value as DateTime?;
                if (date.HasValue && date.Value <= DateTime.Today)
                {
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.DarkRed;
                    dataGridView1[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.White;
                    
                }
                int countDarkRed = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Date1"].Style.BackColor == Color.DarkRed)
                        countDarkRed++;
                }
                label1.Text = $"dark = {countDarkRed}";
            }
        }
