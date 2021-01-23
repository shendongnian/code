    Rectangle area = Screen.GetWorkingArea(this);
    Bitmap bmp = new Bitmap(area.Width, area.Height);
    using(Graphics g = Graphics.FromImage(bmp))
        g.CopyFromScreen(area.Left, area.Height, 0, 0, new Size(area.Width, area.Height));
    this.BackgroundImage = bmp;
