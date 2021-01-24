    bool byCode;    
    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        if(byCode == true)
        {
             //textbox was changed by the code...
        }
        else
        {
             //textbox was changed by the user...
        }
    }
    
    private void Button_Click(object sender, EventArgs e)
    {
        byCode = true; 
        textBox.Text = "hello world";
        byCode = false;
    }
