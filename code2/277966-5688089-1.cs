    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 1)
        {
             e.Control.KeyPress += TextboxNumeric_KeyPress;
        }
    }
    private void TextboxNumeric_KeyPress(object sender, KeyPressEventArgs e)
    {
        bool nonNumberEntered = true;
        if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8)
        {
            nonNumberEntered = false;
        }
        if (nonNumberEntered)
         {
            // Stop the character from being entered into the control since it is non-numerical.
            e.Handled = true;
        }
        else
        {
            e.Handled = false;
        }
    }
