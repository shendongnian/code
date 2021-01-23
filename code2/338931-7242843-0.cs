    // get the bounding area of the screen containing (0,0)
    // remember in a multidisplay environment you don't know which display holds this point
    Drawing.Rectangle bounds = Forms.Screen.GetBounds(System.Drawing.Point.Empty);
    // create the bitmap to copy the screen shot to
    Drawing.Bitmap bitmap = new Drawing.Bitmap(bounds.Width, bounds.Height);
    // now copy the screen image to the graphics device from the bitmap
    using (Drawing.Graphics gr = Drawing.Graphics.FromImage(bitmap))
    {
        gr.CopyFromScreen(Drawing.Point.Empty, Drawing.Point.Empty, bounds.Size);
    }
