    private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        DataGridViewTextBoxCell cell = dataGridView1[2, e.RowIndex] as DataGridViewTextBoxCell;
        if (cell != null)
        {
             if (e.ColumnIndex == 2)
             {
                 char[] chars = e.FormattedValue.ToString().ToCharArray();
                 foreach (char c in chars)
                 {
                      if (char.IsDigit(c) == false)
                      {
                               MessageBox.Show("You have to enter digits only");
                               e.Cancel = true;
                               break;
                        }
                  }
              }
         }
    }
