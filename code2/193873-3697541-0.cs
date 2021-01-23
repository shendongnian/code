    public void dataGridView_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            var selectedCell = dataGridView.SelectedCells[0];
            // do something with selectedCell...
        }
    }
