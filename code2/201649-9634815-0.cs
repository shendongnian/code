         Intervening keyup messes up the typing and the cursor in the text, as getting the value messes up the carte position
       Hence the iffy solution of getting the textboxbase and setting the value of the caret ourselves.
        private void numericUpDown_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                NumericUpDown numericUpDownsender = (sender as NumericUpDown);
                TextBoxBase txtBase = numericUpDownsender.Controls[1] as TextBoxBase;
                int currentCaretPosition = txtBase.SelectionStart;
                numericUpDownsender.DataBindings[0].WriteValue();
                txtBase.SelectionStart = currentCaretPosition;
            }
            catch (Exception ex)
            {
                
            }
        }
