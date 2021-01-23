    private void MyGridView_SelectionChanged(object sender, EventArgs e)
    {
          for (int i = 0; i < MyGridView.SelectedRows.Count; i++)
          {
              MyTextBox.Text = MyGridView.SelectedRows[i].Cells[0].Value.ToString(); //assuming column 0 is the cell you're looking for
    
              // do your other stuff
          }
    }
