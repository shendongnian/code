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
