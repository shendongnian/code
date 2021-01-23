    var bmp = new Bitmap(16, 16);
    using (var g = Graphics.FromImage(bmp))
    {
        g.DrawImage(child.Icon.ToBitmap(), new Rectangle(0, 0, 16, 16));
    }
    var newIcon = Icon.FromHandle(bmp.GetHicon());
    child.Icon = newIcon;
    // ...
    child.Show();
            
