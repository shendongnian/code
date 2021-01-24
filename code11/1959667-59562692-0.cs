    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var xml = dt.Rows[e.RowIndex][0].ToString();
                Form2 display = new Form2(xml);
                display.Show();
                
            }
        }
