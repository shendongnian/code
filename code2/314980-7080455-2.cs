    public static int Cm2Pixel(double WidthInCm)
    {
        double HeightInCm = WidthInCm;
        return Cm2Pixel(WidthInCm, HeightInCm).Width;
    } // End Function Cm2Pixel
    
    
    public static System.Drawing.Size Cm2Pixel(double WidthInCm, double HeightInCm)
    {
        float sngWidth = (float)WidthInCm; //cm
        float sngHeight = (float)HeightInCm; //cm
        using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(1, 1))
        {
            sngWidth *= 0.393700787f * bmp.HorizontalResolution; // x-Axis pixel
            sngHeight *= 0.393700787f * bmp.VerticalResolution; // y-Axis pixel
        }
    
        return new System.Drawing.Size((int)sngWidth, (int)sngHeight);
    } // End Function Cm2Pixel
