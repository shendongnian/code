    UpdateImageData(()=>
    {
        int radius = 10; 
        Set the number of pixel you want to use here
        
        //Calculate the numbers based on radius
        int x0 = Math.Max(e.X - (radius / 2), 0),
            y0 = Math.Max(e.Y - (radius / 2), 0),
            x1 = Math.Min(e.X + (radius / 2), pictureBox1.Width),
            y1 = Math.Min(e.Y + (radius / 2), pictureBox1.Height);
        
        Bitmap bm = pictureBox1.Image as Bitmap; //Get the bitmap (assuming it is stored that way)
           
        for (int ix = x0; ix < x1; ix++)
        {
            for (int iy = y0; iy < y1; iy++)
            {
                bm.SetPixel(ix, iy, Color.Black); //Change the pixel color, maybe should be relative to bitmap
            }
        }
        pictureBox1.Refresh(); //Force refresh
    }
