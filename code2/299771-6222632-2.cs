    private static Image PasteImage(Image startimage, Size size, Point startpoint) 
    {
	    int width = Math.Max(size.Width, startpoint.X + startimage.Width);
	    int height = Math.Max(size.Width, startpoint.Y + startimage.Height);
	    var bmp = new Bitmap(width, height);		
	    using (Graphics g = Graphics.FromImage(bmp)) {
	        g.Clear(Color.Black);
	 	    g.DrawImage(startimage, new Rectangle(startpoint, startimage.Size));
 	    }  
	    return bmp;
    }
