            bool invalid=false;
            private void textBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if ((e.KeyCode & Keys.Enter) == Keys.Enter)
                {
                    invalid = true;
                }
            }
    
            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (invalid)
                {
                    e.Handled = true;
                }
                invalid = false;
            }
   
