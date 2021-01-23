    private void  TextBox_KeyPress(object sender, EventArgs e)        
    {        
            TextBox textBox = sender as TextBox()
            if (sender == null)
                return;
            
            bool bTest = txtRegExStringIsValid(textBox Text.ToString());
            ToolTip tip = new ToolTip();                      
            if (bTest == false)                    {                        
                tip.Show("Only A-I", textbox[1,1], 2000);                        
            textBox Text = " ";     
    }
