        private static void CreateBarcode(string code)
        {
            var myBitmap = new Bitmap(500,50);
            var g = Graphics.FromImage(myBitmap);
            var jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            g.Clear(Color.White);
            var strFormat = new StringFormat {Alignment = StringAlignment.Center};
            g.DrawString(code, new Font("Free 3 of 9", 50), Brushes.Black, new RectangleF(0, 0, 500, 50), strFormat);
            var myEncoder = Encoder.Quality;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            myBitmap.Save(@"c:\Barcode.jpg", jgpEncoder, myEncoderParameters);
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        } 
