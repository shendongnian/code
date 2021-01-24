    private void TbSalary_KeyPress(object sender, KeyPressEventArgs e)
    {
        char number = e.KeyChar;
        TextBox box = sender as TextBox;
    
        if (number >= '0' && number <= '9' || number < ' ')
            return; // numbers as well as backspaces, tabs: business as usual
        else if (number == ',') {  
            // We don't want to allow several commas, right?
            int p = box.Text.IndexOf(',');
    
            // So if we have a comma already...
            if (p >= 0) { 
                // ... we don't add another one
                e.Handled = true;
    
                // but place caret after the comma position
                box.SelectionStart = p + 1;
                box.SelectionLength = 0;  
            }  
            else if (box.SelectionStart == 0) {
                // if we don't have comma and we try to add comma at the 1st position 
                e.Handled = true;
                // let's add it as "0,"
                box.Text = "0," + box.Text.Substring(box.SelectionLength);
                box.SelectionStart = 2;
           } 
        }
        else  
            e.Handled = true; // all the other characters (like '+', 'p') are banned
    }
