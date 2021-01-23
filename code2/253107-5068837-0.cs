    string text = "Sri Lanka";
    Graphics g = e.Graphics;
    Font font = new Font("Arial", 10);
    Brush brush = new SolidBrush(Color.Black);
    float lineSpacing = 0.5f;
    
    SizeF size = g.MeasureString("A", font);
    
    float pos = 0.0f;
    for ( int i = 0; i < text.Length; ++i )
    {
        string charToDraw = new string(textIdea, 1);
        g.DrawString(charToDraw, font, brush, pos, 0.0f);
        SizeF sizeChar = g.MeasureString(charToDraw, font);
        pos +=  sizeChar.Width + size.Width * lineSpacing;
    }
