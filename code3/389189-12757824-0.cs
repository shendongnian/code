        bool keyup = false;
        bool keyleft = false;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                keyup = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                keyleft = true;
            }
            if (keyleft && keyup)
            {
                Console.Beep(234, 589);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                keyup = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                keyleft = false;
            }
        }
