            private unsafe Region GetRegion(Bitmap bckImage)
        {
            GraphicsPath path = new GraphicsPath();
            int w = bckImage.Width;
            int h = bckImage.Height;
            BitmapData bckdata = null;
            try
            {
                bckdata = bckImage.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                uint* bckInt = (uint*)bckdata.Scan0;
                for (int j = 0; j < h; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        if ((*bckInt & 0xff000000) != 0)
                        {
                            path.AddRectangle(new Rectangle(i, j, 1, 1));
                        }
                        bckInt++;
                    }
                }
                bckImage.UnlockBits(bckdata); bckdata = null;
            }
            catch
            {
                if (bckdata != null)
                {
                    bckImage.UnlockBits(bckdata);
                    bckdata = null;
                }
            }
            Region region = new System.Drawing.Region(path);
            RectangleF[] rects = region.GetRegionScans(new Matrix());
            RectangleF c = RectangleF.Empty;
            for (Int32 i = 1; i < rects.Length; i++)
            {
                if (i == 1)
                {
                    c = RectangleF.Union(rects[i - 1], rects[i]);
                }
                else
                {
                    c = RectangleF.Union( c , rects[i]);
                }
            }
            path.Dispose();
            path = null;
            return region;
        }
