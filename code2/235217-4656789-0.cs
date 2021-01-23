        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (
                e.KeyCode == Keys.Left || 
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Down ||
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Enter || 
                e.KeyCode == Keys.Escape
                )
            {
                e.SuppressKeyPress = true;
                return;
            }
            //do sth...
        }
