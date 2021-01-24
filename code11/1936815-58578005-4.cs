    private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                textBox1.Focus();
                e.Handled = true; //To use F10, you need to set the handled state to true
            } else if (e.KeyCode == Keys.F11)
            {
                textBox2.Focus();
            }
        }
