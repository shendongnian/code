    // Assume for simplicity the image is size w*h, and the graphics is the same size. 
    // The ROI is a rectangle named roiRect.
    g.DrawImageUnscaled(image, 0, 0 , w, h);
    g.SetClip(roiRect);
    g.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Black)), 0, 0, w, h);
    g.ResetClip();    
