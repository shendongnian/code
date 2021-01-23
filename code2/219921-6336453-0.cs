    public static string GetMimeType(Image i)
    {
    	var imgguid = i.RawFormat.Guid;
    	foreach (ImageCodecInfo codec in ImageCodecInfo.GetImageDecoders()) 
        {
    		if (codec.FormatID == imgguid)
    			return codec.MimeType;
    	}
    	return "image/unknown";
    }
