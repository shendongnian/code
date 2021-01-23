    ImageCodecInfo tiff = null;
    foreach ( ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders() )
    {
        if ( codec.MimeType == "image/tiff" )
        {
            tiff = codec;
            break;
        }
    }
    Encoder encoder = Encoder.SaveFlag;
    EncoderParameters parameters = new EncoderParamters(1);
    parameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.MultiFrame);
    bitmap1.Save(newFileName, tiff, parameters);
    parameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.FrameDimensionPage);
    bitmap2.SaveAdd(newFileName, tiff, paramters);
    parameters.Param[0] = new EncoderParameter(encoder, (long)EncoderValue.Flush);
    bitmap2.SaveAdd(parameters);
