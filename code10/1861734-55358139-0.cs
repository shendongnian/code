    private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
         if(sender is DataGridView)
         {
            DataGridView dgv = (DataGridView)sender;
            for (int i = 1; i <= 5; i++){
              if (dgv.Name == ("dgv" + i.ToString())){
                   dgv.Rows[0].Cells[0].BackColor = Color.Red;
              }
            }
         }
    }
