    private void lstBox_DrawItem(object sender, _
              System.Windows.Forms.DrawItemEventArgs e)
    {
        //
        // Draw the background of the ListBox control for each item.
        // Create a new Brush and initialize to a Black colored brush
        // by default.
        //
        e.DrawBackground();
        Brush myBrush = Brushes.Black;
        //
        // Determine the color of the brush to draw each item based on 
        // the index of the item to draw.
        //
        switch (e.Index)
        {
            case 0:
                myBrush = Brushes.Red;
                break;
            case 1:
                myBrush = Brushes.Orange;
                break;
            case 2:
                myBrush = Brushes.Purple;
                break;
        }
        //
        // Draw the current item text based on the current 
        // Font and the custom brush settings.
        //
        e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(), 
            e.Font, myBrush,e.Bounds,StringFormat.GenericDefault);
        //
        // If the ListBox has focus, draw a focus rectangle 
        // around the selected item.
        //
        e.DrawFocusRectangle();
    }
