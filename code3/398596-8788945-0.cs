    public static Bitmap CropRotatedRect(Bitmap source, Rectangle rect, float angle, bool HighQuality)
    {
        int[] offsets = { -1, 1, 0 }; //place 0 last!
        Bitmap result = new Bitmap(rect.Width, rect.Height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.InterpolationMode = HighQuality ? InterpolationMode.HighQualityBicubic : InterpolationMode.Default;
            foreach (int x in offsets)
            {
                foreach (int y in offsets)
                {
                    using (Matrix mat = new Matrix())
                    {
                        //create the appropriate filler offset according to x,y
                        //resulting in offsets (-1,-1), (-1, 0), (-1,1) ... (0,0)
                        mat.Translate(-rect.Location.X - rect.Width * x, -rect.Location.Y - rect.Height * y);
                        mat.RotateAt(angle, rect.Location);
                        g.Transform = mat;
                        g.DrawImage(source, new Point(0, 0));
                    }
                }
            }
        }
        return result;
    }
