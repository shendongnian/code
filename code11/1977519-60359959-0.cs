    private void UpdateTextOnTextBox(object sender, TextChangedEventArgs e)
    {
       try
       {
         textbox4.Text = ((float.Parse(textbox1.Text) + float.Parse(textbox2.text)+ float.Parse(textbox3.text)).ToString();
    
       }
       catch (Exeption ex)
       {
         textbox4.Text = ex.Message;
       }
    
    }
