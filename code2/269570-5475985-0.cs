    public static ImageCodecInfo FindEncoder(ImageFormat format) { 
        if (format == null)
            throw new ArgumentNullException("format");
    
        foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders()) {
            if (codec.FormatID.Equals(format.Guid)) {
                return codec;
            }
        }
    
        return null;
    }
