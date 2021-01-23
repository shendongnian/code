        private void BtnKeyboard_Click(object sender, EventArgs e)
        { 
            if (MasterKeyboard.Visible)
            {
                btnKeyboard.ButtonImage = Properties.Resources._001_22;
                MasterKeyboard.Visible = false;
                _lastFocusedControl.Focus();
            }
            else
            {
                btnKeyboard.ButtonImage = Properties.Resources._001_24;
                MasterKeyboard.Visible = true;
                MasterKeyboard.BringToFront();
                _lastFocusedControl.Focus();
            }
        }
        private Control _lastFocusedControl;
        private void BtnKeyboard_MouseHover(object sender, EventArgs e)
        {
            if (ActiveControl!=btnKeyboard)
                _lastFocusedControl = ActiveControl;
        }
