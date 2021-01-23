        void oTextBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            int val = (int)e.KeyChar;
            if (val >= 0x30 && val <= 0x39)
            {
                //Digits are ok
            }
            else if (val == 0x08)
            {
                //Backspace is ok
            }
            else
            {
                //Other are disallowed
                e.Handled = true;
            }
        }
