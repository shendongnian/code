    private void tbOwnerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //===================to accept only charactrs & space/backspace=============================================
            
            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                e.Handled = true;
                base.OnKeyPress(e);
                MessageBox.Show("enter characters only");
            }
