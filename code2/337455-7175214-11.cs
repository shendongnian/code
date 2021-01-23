    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var image = Properties.Resources.SomeImage; //Import via Resource Manager
        //Don't use pictureBox1.Image property because it will
        //draw the image 2 times.
        //Make sure the pictureBox1.Image property is null in Deisgn Mode
        if (image != null)
        {
            var g = e.Graphics;
            // -- Optional -- //
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // -- Optional -- //
            g.DrawImage(image, 
                pictureBox1.Width - image.Width,  // to right
                pictureBox1.Height - image.Height, // to bottom
                image.Width,
                image.Height);
        }
    }
