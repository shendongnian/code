    private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dataGridView1.CurrentCell = dataGridView1[hit.ColumnIndex, hit.RowIndex];
                contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
            }
        }
    }
