        private Keys CurrentKey = Keys.None;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentKey == Keys.None)
            {
                CurrentKey = e.KeyData;
                // TODO: put your key trigger here
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == CurrentKey)
            {
                // TODO: put you key end trigger here
                CurrentKey = Keys.None;
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
