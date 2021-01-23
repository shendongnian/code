    Image i = new Bitmap(size, size);
    Graphics g = Graphics.FromImage(i);
    
    // When this line is uncommented TextRenderingHint is broken for ALL other Graphics-Objects.
    // Setting "g.TextRenderingHint" later works sometimes in unpredictable ways.
    //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
    ...
