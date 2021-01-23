    void gkh_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.K)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                SendKeys.Send("b");
                e.Handled = true;  
            }
            else
            {
                SendKeys.Send("a");
                e.Handled = true;  
            }
        }
 
    }
