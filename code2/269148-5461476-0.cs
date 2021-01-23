        public static byte[] CreateGridImage(
            int maxXCells, 
            int maxYCells,
            int cellXPosition, 
            int cellYPosition)
        {
            // Specify pixel format if you like..
            using(var bmp = new System.Drawing.Bitmap(maxXCells, maxYCells)) 
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    // Do your drawing here
                }
                var memStream = new MemoryStream();
                bmp.Save(memStream, ImageFormat.Jpeg);
                return memStream.ToArray();
            }
        }
 
