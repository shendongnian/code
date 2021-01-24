    if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.BmpDecoderId)
    {
         encoderGuid = BitmapEncoder.BmpEncoderId;
    }
    else if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.GifDecoderId)
    {
         encoderGuid = BitmapEncoder.GifEncoderId;
    }
    else if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.JpegDecoderId)
    {
         encoderGuid = BitmapEncoder.JpegEncoderId;
    }
    else if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.JpegXRDecoderId)
    {
         encoderGuid = BitmapEncoder.JpegXREncoderId;
    }
    else if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.PngDecoderId)
    {
         encoderGuid = BitmapEncoder.PngEncoderId;
    }
    else if (bitmapDecoder.DecoderInformation.CodecId == BitmapDecoder.TiffDecoderId)
    {
         encoderGuid = BitmapEncoder.TiffEncoderId;
    }
    else
    {
          throw new NotSupportedException("unknown Codec");
    }
