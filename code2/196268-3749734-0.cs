    private void copy_Click(object sender, EventArgs e)
    {
       if (convertedText.Text.Equals(""))
         return; 
     
        Clipboard.SetText(convertedText.Text);
        convertedText.Text = Clipboard.GetText();          
    }
