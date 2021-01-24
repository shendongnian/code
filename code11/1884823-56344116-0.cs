    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
    encoder.QualityLevel = 100;
    BitmapFrame bFrame = BitmapFrame.Create(rtb, null, meta, icc);
    encoder.Frames.Add(bFrame);
    
    using (var stream = new MemoryStream())
    {
    	encoder.Save(stream);
    
    	using (var bmpOutput = new System.Drawing.Bitmap(stream))
    	{
    		System.Drawing.Imaging.ImageCodecInfo myEncoder = GetEncoder(ImageFormat.Jpeg); 
    
    		var encoderParameters = new System.Drawing.Imaging.EncoderParameters(1);
    		encoderParameters.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
    
    		bmpOutput.SetResolution(300.0f, 300.0f);
    		bmpOutput.Save(filePath, myEncoder, encoderParameters);
    	}
    }
