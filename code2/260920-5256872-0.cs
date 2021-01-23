    public void ImageDrawing()
    {
        // NOTE: There are several ways you can load an image
        // this is just using an existing file on disk
        var img = Image.FromFile("myimage.jpg");
        using (var g = Graphics.FromImage(img))
        {
            g.DrawLine(Pens.AliceBlue, new Point(), new Point(img.Width - 1, img.Height - 1));
        }
        this.BackgroundImage = img;
    }
