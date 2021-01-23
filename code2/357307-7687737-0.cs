    protected void ComboBox1_DrawItem(object sender, 
        System.Windows.Forms.DrawItemEventArgs e)
    {
        float size = 0;
        System.Drawing.Font myFont;
        FontFamily font= null;
        
        //Color and font based on index//
        Brush brush;
        switch(e.Index)
        {
            case 0:
                size = 10;
                brush = Brushes.Red;
                family = font.GenericSansSerif;
                break;
            case 1:
                size = 20;
                brush = Brushes.Green;
                font = font.GenericMonospace;
                break;
        }
        myFont = new Font(font, size, FontStyle.Bold);
        string text = ((ComboBox)sender).Items[e.Index].ToString();
        e.Graphics.DrawString(text, myFont, brush, e.Bounds.X, e.Bounds.Y);
