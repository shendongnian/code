    private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(@"C:\Users\ercan.acar\Pictures\Current CR Sticker.PNG");
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            System.Drawing.Imaging.Encoder myEncoder =System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder,
                50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            Stream stream=new MemoryStream();
            bmp1.Save(stream, jpgEncoder,myEncoderParameters);
            //bmp1.Save(@"C:\Users\ercan.acar\Documents\TestPhotoQualityFifty.jpg",);
            
            var size = stream.Length;
            
        }
