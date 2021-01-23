    using System.Drawing.Imaging;
    private void saveJpeg(string path, Bitmap img, long quality)
    {
        // Encoder parameter for image quality
            
        EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
        // Jpeg image codec
        ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");
        if (jpegCodec == null)
        return;
        EncoderParameters encoderParams = new EncoderParameters(1);
        encoderParams.Param[0] = qualityParam;
        img.Save(path, jpegCodec, encoderParams);
    }
    private ImageCodecInfo getEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
    
        // Find the correct image codec
        for (int i = 0; i < codecs.Length; i++)
        if (codecs[i].MimeType == mimeType)
        return codecs[i];
        return null;
    }
