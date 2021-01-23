    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
        {
            //Set a var that determined whether or not the checkbox is selected
            bool selected = (bool)this.dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            //Do the flip-flop here
            switch (e.ColumnIndex)
            {
                //If the checkbox in the Add column changed, flip the value of the corresponding Delete column
                case 0:
                    this.dataGridView1[1, e.RowIndex].Value = !selected;
                    break;
                //If the checkbox in the Delete column changed, flop the value of the corresponding Add column
                case 1:
                    this.dataGridView1[0, e.RowIndex].Value = !selected;
                    break;
            }
        }
    }
    //You may need to do something goofy like this to update the DataGrid 
    private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
        
        if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
        {
            this.dataGridView1.EndEdit();
        }
    }
