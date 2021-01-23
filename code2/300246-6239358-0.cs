    void SetTransparent(ref Bitmap b)    
    {   
        const float selectivity = 20f;  // set it to some number much larger than 1 but less than 255
        for (int i = 0; i < b.Width; i++)
        {        
            for (int ii = 0; ii < b.Height; ii++)
            {
                Color cc = b.GetPixel(i, ii);
                float avgg = (cc.R + cc.G + cc.B) / 3f;
                float durch = Math.Min(255f, (255f - avgg) * selectivity);
                b.SetPixel(i, ii, Color.FromArgb((int)durch, cc.R, cc.G, cc.B));
            }
        }
    }
