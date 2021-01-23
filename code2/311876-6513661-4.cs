    // Assumes myImage is the PNG you are converting
    using (var b = new Bitmap(myImage.Width, myImage.Height)) {
        b.SetResolution(myImage.HorizontalResolution, myImage.VerticalResolution);
        using (var g = Graphics.FromImage(b)) {
            g.Clear(Color.White);
            g.DrawImageUnscaled(myImage, 0, 0);
        }
        
        // Now save b as a JPEG like you normally would
    }
