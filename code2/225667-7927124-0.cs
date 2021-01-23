    private void MyTextBox_Resize( object sender, EventArgs e )
    {
        // Grab a reference to the TextBox
        TextBox tb = sender as TextBox; 
    
        // Figure out how much space is used for borders, etc. 
        int chromeHeight = tb.Height - tb.ClientSize.Height;
    
        // Create a proposed size that is very tall, but exact in width. 
        Size proposedSize = new Size( tb.ClientSize.Width, int.MaxValue );
    
        // Measure the text using the TextRenderer
        Size textSize = TextRenderer.MeasureText( tb.Text, tb.Font,
            proposedSize, TextFormatFlags.TextBoxControl
             | TextFormatFlags.WordBreak );
    
        // Adjust the height to include the text height, chrome height,
        // and vertical margin
        tb.Height = chromeHeight + textSize.Height 
            + tb.Margin.Vertical; 
    }
