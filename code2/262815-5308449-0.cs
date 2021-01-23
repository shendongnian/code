    // Create a new bitmap object
    using (Bitmap bmp = new Bitmap(200, 300))
    {
        // Obtain a Graphics object from that bitmap
    	using (Graphics g = Graphics.FromImage(bmp))
        {
            // Draw onto the bitmap here
            // ....
    	    g.DrawRectangle(Pens.Red, 10, 10, 50, 50);
    	}
     
        // Save the bitmap to a file on disk, or do whatever else with it
        // ...
    	bmp.Save("C:\\MyImage.bmp");
    }
