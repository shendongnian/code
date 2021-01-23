    private void dataGridView1_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string key = row.Cells[1].Value.ToString();
            
            foreach ( DataGridViewRow affected in dataGridView1.Rows)
            {
                if ( affected.Cells[1].Value.ToString( ) == key )
                {
                    for ( int i=2; i < dataGridView1.Columns.Count; i++ )
                    {
                        affected.Cells[i].Value = row.Cells[i].Value;
                    }
                }
            }
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }
