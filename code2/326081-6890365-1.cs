    int repeatTimes= 10;
    Image imageSource = Image.FromFile(@"your image file path");//or your resource..
     
    Bitmap myCombinationImage = new Bitmap(new Size(imageSource.Width, imageSource.Heigh * repeatTimes);
    
    using (Graphics graphics = Graphics.FromImage(myCombinationImage))
    {
        Point newLocation = new Point(0, 0);
        for (int imageIndex; imageIndex < repeatTimes; imageIndex++)
        {
            graphics.DrawImage(imageSource, newLocation);
            newLocation = new Point(newLocation.X, newLocation.Y + imageSource.Height);
        }
    }
    pictureBox.Image = myCombinationImage;
