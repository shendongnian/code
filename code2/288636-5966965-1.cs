    public static Icon GetIcon(string text)
    {
        //Create bitmap, kind of canvas
        Bitmap bitmap = new Bitmap(32, 32);
    
        Icon icon = new Icon(@"Images\PomoDomo.ico");
        System.Drawing.Font drawFont = new System.Drawing.Font("Calibri", 16, FontStyle.Bold);
        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
    
        System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap);
    
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
        graphics.DrawIcon(icon, 0, 0);            
        graphics.DrawString(text, drawFont, drawBrush, 1, 2);
    
        //To Save icon to disk
        bitmap.Save("icon.ico", System.Drawing.Imaging.ImageFormat.Icon);
        
        Icon createdIcon = Icon.FromHandle(bitmap.GetHicon());
        
        drawFont.Dispose();
        drawBrush.Dispose();
        graphics.Dispose();
        bitmap.Dispose();
    
        return createdIcon;
    }
