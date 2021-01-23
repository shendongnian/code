            var bmp = new Bitmap(640, 480, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            System.Drawing.Imaging.BitmapData bd = null;
            try {
                bd = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                var pointer = bd.Scan0;
                // Make the call, passing *pointer*
                //...
            }
            finally {
                if (bd != null) bmp.UnlockBits(bd);
            }
            // Do something with <bmp>
            //...
