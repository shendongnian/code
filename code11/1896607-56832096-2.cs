    private void tiff2png(string imagepath, string outputpath)
            {
                //using System.Drawing;
                //using System.Drawing.Imaging;
                using (var tiff = new Bitmap(imagepath))
                {
                    tiff.Save(outputpath, ImageFormat.Png);
                }
            }
