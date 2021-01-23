    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
    
        Image myIcon = Image.FromFile(@"C:\Users\me\Pictures\test.jpg");
    
        int x = 0;
        int y = 14;
    
        Rectangle myIconDrawingRectangle = new Rectangle(x, y, 1000, 16);
        using (TextureBrush brush = new TextureBrush(myIcon, WrapMode.Tile))
        {
            e.Graphics.FillRectangle(brush, myIconDrawingRectangle);
        }
    
        e.Graphics.DrawLine(Pens.Black, 0, 16, 1000, 16);
    }
