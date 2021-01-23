    private void cell_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Enter)
        {
            // modify/cast/transform e here to DataGridViewCellEventArgs
            dataGridView_CellContentClick(sender, e) 
        }
    }
