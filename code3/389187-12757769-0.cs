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
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (keyleft && keyup)
            {
                Console.Beep(234, 589);
            }
        }
