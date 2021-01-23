    using (System.Drawing.Bitmap sourceImg = new System.Drawing.Bitmap(@"c:\image.jpg")) 
    { 
        YLScsDrawing.Imaging.Filters.FreeTransform filter = new YLScsDrawing.Imaging.Filters.FreeTransform(); 
        filter.Bitmap = sourceImg;
        // assign FourCorners (the four X/Y coords) of the new perspective shape
        filter.FourCorners = new System.Drawing.PointF[] { new System.Drawing.PointF(0, 0), new System.Drawing.PointF(300, 50), new System.Drawing.PointF(300, 411), new System.Drawing.PointF(0, 461)}; 
        filter.IsBilinearInterpolation = true; // optional for higher quality
        using (System.Drawing.Bitmap perspectiveImg = filter.Bitmap) 
        {
            // perspectiveImg contains your completed image. save the image or do whatever.
        } 
    }
