        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = "ColumnName";
            col.HeaderText = "HeaderTest";
            col.TrueValue = "True";
            col.FalseValue = "False";
            this.dataGridView1.Columns.Add(col);
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "ColumnName")
            {
                DataGridViewCheckBoxCell cell = this.dataGridView1.CurrentCell as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) 
                   //your code here            
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dataGridView1.Columns[e.ColumnIndex].Name == "ColumnName")
            {
                DataGridViewCheckBoxCell cell = this.dataGridView1.CurrentCell as DataGridViewCheckBoxCell;
                if (cell.Value == cell.TrueValue) 
                 {
                    //your code here
                 }
            }
        }
