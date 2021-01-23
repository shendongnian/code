    using System.Drawing;
    ...
    
    private void textBoxTitle_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Determine the correct size for the text box based on its text length   
        // get the current text box safely
        TextBox tb = sender as TextBox;
        if (tb == null) return;
        SizeF stringSize;
        // create a graphics object for this form
        using(Graphics gfx = this.CreateGraphics())
        {
            // Get the size given the string and the font
            stringSize = gfx.MeasureString(tb.Text, tb.Font);
        }
        // Resize the textbox 
        tb.Width = (int)Math.Round(stringSize.Width, 0);
    }
