    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                this.dataGridView1.CellEnter += new DataGridViewCellEventHandler(myDataGrid_CellEnter);
            }
            void myDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
            {
                if ((this.dataGridView1.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) ||
                    (this.dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn))
                {
                    this.dataGridView1.BeginEdit(false);
                }
            }
