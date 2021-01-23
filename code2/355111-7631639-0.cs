    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
       DataGridView theGrid = sender as DataGridView;
       if(theGrid != null)
       {
          DataGridViewCell selectedCell = theGrid.SelectedCells[0];
          //Do your logic here
       }
    }
