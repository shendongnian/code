    private void MyDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox currentCell = e.Control as TextBox;
            if (currentCell != null
                && myDataGridView.CurrentCell.ColumnIndex == NameOfYourColumn.Index) //or compare using column name
            {
                currentCell.RightToLeft = RightToLeft.Yes;
            }
        }
 
