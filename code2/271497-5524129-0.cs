        private void AddColumnsProgrammatically()
        {
            var col3 = new DataGridViewTextBoxColumn();
            var col4 = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {col3,col4});
            col3.HeaderText = "Column3";
            col3.Name = "Column3";
            col4.HeaderText = "Column4";
            col4.Name = "Column4";
        }
