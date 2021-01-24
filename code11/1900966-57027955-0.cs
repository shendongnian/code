            byte[,] newImageAsBytes = new byte[ImageAsBytes.GetLength(1), ImageAsBytes.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = ImageAsBytes.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < ImageAsBytes.GetLength(0); oldRow++)
                {
                    newImageAsBytes[newRow, newColumn] = ImageAsBytes[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            byte[] b = ObjectToByteArray(newImageAsBytes);
            var bitmap = new Bitmap(608, 608, PixelFormat.Format24bppRgb); // 608 is my image size and I am working with a camera that uses BayerRGB8
            var bitmap_data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);
            Marshal.Copy(b, 0, bitmap_data.Scan0, b.Length);
            bitmap.UnlockBits(bitmap_data);
            var result = bitmap as Image; // this line not even really necessary
            PictureBox.Image = result;
