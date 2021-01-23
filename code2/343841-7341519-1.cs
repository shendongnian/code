    // You must handle the DrawItem event for owner-drawn combo boxes.  
    // This event handler changes the color, size and font of an 
    // item based on its position in the array.
    protected void ComboBox1_DrawItem(object sender, 
                System.Windows.Forms.DrawItemEventArgs e)
    {
        float size = 0;
        System.Drawing.Font myFont;
        FontFamily family = null;
        System.Drawing.Color animalColor = new System.Drawing.Color();
        switch(e.Index)
        {
            case 0:
                size = 30;
                animalColor = System.Drawing.Color.Gray;
                family = FontFamily.GenericSansSerif;
                break;
            case 1:
                size = 10;
                animalColor = System.Drawing.Color.LawnGreen;
                family = FontFamily.GenericMonospace;
                break;
            case 2:
                size = 15;
                animalColor = System.Drawing.Color.Tan;
                family = FontFamily.GenericSansSerif;
                break;
        }
        // Draw the background of the item.
        e.DrawBackground();
        // Create a square filled with the animals color. Vary the size
        // of the rectangle based on the length of the animals name.
        Rectangle rectangle = new Rectangle(2, e.Bounds.Top+2, 
                e.Bounds.Height, e.Bounds.Height-4);
        e.Graphics.FillRectangle(new SolidBrush(animalColor), rectangle);
        // Draw each string in the array, using a different size, color,
        // and font for each item.
        myFont = new Font(family, size, FontStyle.Bold);
        e.Graphics.DrawString(animals[e.Index], myFont, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X+rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
        // Draw the focus rectangle if the mouse hovers over an item.
        e.DrawFocusRectangle();
    }
