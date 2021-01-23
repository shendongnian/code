    ImageCodecInfo jpgInfo = ImageCodecInfo.GetImageEncoders()
        .Where(codecInfo => codecInfo.MimeType == "image/jpeg").First();
    using (EncoderParameters encParams = new EncoderParameters(1))
    {
    	encParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
    	//quality should be in the range [0..100]
    	image.Save(outputStream, jpgInfo, encParams);
    }
