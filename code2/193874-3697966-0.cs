    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      DataGridViewTextBoxEditingControl tb =(DataGridViewTextBoxEditingControl)e.Control;
      tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
    
      e.Control.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
    }
    
    
    private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      //when i press enter,bellow code never run?
      if (e.KeyChar==(char)Keys.Enter)
      {
        MessageBox.Show("You press Enter");
      }
    }
