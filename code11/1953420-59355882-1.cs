    private void ReverseImage_Click(object sender, EventArgs e)
    {
        var imageName = "GroupBox.ExpansionIndicator_Chevron.bmp";
        System.IO.Stream stream = typeof(UltraExpandableGroupBox).Module.Assembly.GetManifestResourceStream(typeof(UltraExpandableGroupBox), imageName);
        Image image = null;
        if (stream != null)
        {
            image = Bitmap.FromStream(stream);
            ultraExpandableGroupBox1.ExpansionIndicatorExpanded = ResizeImage(image, 16, 16);
            // Rotation
            using (var bmp = new Bitmap(image))
            {
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                image = bmp.Clone() as Image;
            }                
            ultraExpandableGroupBox1.ExpansionIndicatorCollapsed = ResizeImage(image, 16, 16);
        }
    } 
    
    public static Image ResizeImage(Image image, int new_height, int new_width)
    {
        var dest = new Bitmap(new_width, new_height);
        var g = Graphics.FromImage(dest);
        g.InterpolationMode = InterpolationMode.High;
        g.DrawImage(image, (dest.Width - image.Width)/2, (dest.Height-image.Height)/2);
        return dest;
    }
