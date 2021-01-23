    public void save(string filename, Bitmap img, int quality)
    {
       // quality encoding
       EncoderParameter qualParam = new EncoderParameter(Encoder.Quality, quality);
    
       // code for jpeg image type
       ImageCodecInfo jpegCodec = FindEncoderInfo("image/jpeg");
    
       
       EncoderParameters encoderParams = new EncoderParameters(1);
       encoderParams.Param[0] = qualParam;
    
       img.Save(filename, jpegCodec, encoderParams);
    }
    
    private ImageCodecInfo FindEncoderInfo(string mimeType)
    {
       // search through all codecs for all formats
       ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
    
       for (int i = 0; i < codecs.Length; i++)
       {
          if (codecs[i].MimeType == mimeType)
          {
             return codecs[i];
          }
       }
       return null;
    }
