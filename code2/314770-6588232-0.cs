    private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //sort column 0 descending on a 'D' press
            if (e.KeyCode == Keys.D)
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            
            //sort column 0 Ascending on a 'U' press
            if (e.KeyCode == Keys.U)
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
        }
