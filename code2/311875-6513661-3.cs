    // Assumes myImage is the PNG you are converting
    using(Bitmap b = new Bitmap(myImage.Width, myImage.Height)) {
        b.SetResolution(myImage.HorizontalResolution, myImage.VerticalResolution);
        using(Graphics g = Graphics.FromImage(b)) {
            g.Clear(Color.White);
            g.DrawImageUnscaled(myImage, 0, 0);
        }
        
        // Now save b as a JPEG like you normally would
    }
