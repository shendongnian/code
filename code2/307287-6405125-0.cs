    readonly string  TEXTBOX_PREDEFINED_VALUE = "Foo!";
    
    private void textBox4_Leave(object sender, EventArgs e)
            {
    
                try
                {
                    int numberEntered = int.Parse(textBox4.Text);
                    if (numberEntered < 1 || numberEntered > 28)
                    {
    
                       textBox4.Text = TEXTBOX_PREDEFINED_VALUE;
    
                    }
                }
                catch (FormatException)
                {
    
    
                }
            } 
