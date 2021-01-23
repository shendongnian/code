        public void SaveImage(Bitmap image, string filename)
        {
            long quality = 80L;  // adjust as appropriate
            
            var qualityEncoder = Encoder.Quality;
            
            using (var encoderParameter = new EncoderParameter(qualityEncoder, quality))
            using (var encoderParams = new EncoderParameters(1))
            {
                encoderParams.Param[0] = encoderParameter;
                var jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                image.Save(filename, jpegEncoder, encoderParams);
            }
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            return codecs
                .Where(codec => codec.FormatID == format.Guid)
                .FirstOrDefault();
        }
