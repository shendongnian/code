    using System.Text.RegularExpressions;
    int CursorWas;
    string WhatItWas;
    
    private void textBox1_Enter(object sender, EventArgs e)
        {
            WhatItWas = textBox1.Text;
        }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, "^[a-zA-Z ]*$"))
            {
                WhatItWas = textBox1.Text;
            }
            else
            {
                CursorWas = textBox1.SelectionStart == 0 ? 0 : textBox1.SelectionStart - 1;
                textBox1.Text = WhatItWas;
                textBox1.SelectionStart = CursorWas;
            }
        }
