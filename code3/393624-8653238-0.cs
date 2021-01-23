    void grd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
         if ((sender as DataGridView).CurrentCell is DataGridViewCheckBoxCell)
         {
              //Now you know its a checkbox
              //use the ColumnIndex of the CurrentCell and you would know which is the column
              // check the state by casting the value of the cell as boolean
         }
    }
