    Bitmap bm = (Bitmap)Image.FromFile(filePath); 
    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders(); 
    ImageCodecInfo codecInfo = null; 
    foreach (ImageCodecInfo codec in codecs)
    { 
        if (codec.MimeType == "image/jpeg") 
            codecInfo = codec; 
    }
    EncoderParameters ep = new EncoderParameters(); 
    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100); 
    bm.Save("C:\\quality" + x.ToString() + ".jpg", codecInfo, ep);
