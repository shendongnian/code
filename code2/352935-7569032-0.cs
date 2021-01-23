    public Form1()
    {
       InitializeComponent();
       dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
    }
    private void dataGridView1_EditingControlShowing(object sender , DataGridViewEditingControlShowingEventArgs e)
    {
       // Convert the editing control to a TextBox to register for KeyPress event
       TextBox txt_edit = e.Control as TextBox;
       if(txt_edit != null)
       {
          // Remove any existing handler
          txt_edit.KeyPress -= TextBoxKeyPressed;
          // Add the new handler
          txt_edit.KeyPress += TextBoxKeyPressed;
       }
    }
    private void TextBoxKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
       // Test for numeric value or backspace in first column
       // Change this to whatever column you only want digits for
       if (dataGridView1.CurrentCell.ColumnIndex == 0)
       {
          // If its a numeric or backspace, display it.  Not a numeric, ignore it
          e.Handled = (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back));
       }
    }
