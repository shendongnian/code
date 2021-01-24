     public static System.Drawing.Bitmap ResizeImage(System.Drawing.Image image, int width, int height) 
        { 
            //a holder for the result 
            Bitmap result = new Bitmap(width, height); 
    
            //use a graphics object to draw the resized image into the bitmap 
            using (Graphics graphics = Graphics.FromImage(result)) 
            { 
                //set the resize quality modes to high quality 
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality; 
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; 
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; 
                //draw the image into the target bitmap 
                graphics.DrawImage(image, 0, 0, result.Width, result.Height); 
            } 
    
            //return the resulting bitmap 
            return result; 
        } 
