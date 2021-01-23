    Image bitmap = new Bitmap(100, 100); // sample image, load your real image from file here
    using (var g = Graphics.FromImage(bitmap))
    {
        g.FillRectangle(Brushes.Red, new Rectangle(0, 0, bitmap.Width, bitmap.Height)); // Just to fill the background on the sample image, remove this
        var transparentColor = Color.FromArgb(127, Color.Blue); // Create a semitransparent color
        using(Brush brush = new SolidBrush(transparentColor))
        {
            // Create the dot
            g.FillEllipse(brush, new Rectangle(10, 10, 25, 25));
            // Create another dot
            g.FillEllipse(brush, new Rectangle(25, 15, 25, 25));
        }
    }
    myPictureBox.Image = bitmap; // display the image in an Imagebox (optional, you might use your image somewhere else)
