        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 'G')
            {
                // Stop the character from being entered into the control
                e.Handled = true;
                textBox1.Text += 'A';
            }
        }
