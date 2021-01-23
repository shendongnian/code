    private void  TextBox_KeyPress(object sender, EventArgs e)        
    {        
            TextBox tb = sender as TextBox()
            if (sender == null)
                return;
            
            bool bTest = txtRegExStringIsValid(tb.Text.ToString());
            ToolTip tip = new ToolTip();                      
            if (bTest == false)                    {                        
                tip.Show("Only A-I", tb, 2000);                        
            tb .ext = " ";     
    }
