     private void myDataGridView_KeyUp(object sender, KeyEventArgs e)
     {
          // nothing is selected
          if (myDataGridView.SelectedRows.Count == 0)
              return;
          if (e.KeyCode == Keys.Enter)
          {
               string firstColumnValue = myDataGridView.SelectedRows[0].Cells[0].Value.ToString();
               // passes the value through the constructor to the 
               //   second form.
               MySecondForm f2 = new MySecondForm(firstColumnValue);
               f2.Show();
          }
     }
