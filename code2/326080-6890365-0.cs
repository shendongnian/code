    int repeat = 10;
    Bitmap myCombinationImage = new Bitmap(new Size(pictureBox.Width, pictureBox.Heigh * repeat);
    
    using (Graphics graphics = Graphics.FromImage(myCombinationImage))
    {
        Point newLocation = new Point(0, 0);
        for (int imageIndex; imageIndex < repeat; imageIndex++)
        {
            graphics.DrawImage(pictureBox.Image, newLocation);
            newLocation = new Point(newLocation.X, newLocation.Y + pictureBox.Height);
        }
    }
