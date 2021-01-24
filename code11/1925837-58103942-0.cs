        private byte[] CompressImageToQuality(System.Drawing.Image image, int quality)
        {
                EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality); 
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                using (var stream = new System.IO.MemoryStream())
                {
                    image.Save(stream, jpegCodec, encoderParams);
                    return stream.ToArray();
                }
        }
