    public static bool IsValidImage(HttpPostedFileBase file, double maxFileSize, ModelState ms )
    {
    	// make sur the file isnt null.
    	if( file == null )
    		return false;
		
	// the param I normally set maxFileSize is 10MB  10 * 1024 * 1024 = 10485760 bytes converted is 10mb
	var max = maxFileSize * 1024 * 1024;
	// check if the filesize is above our defined MAX size.
	if( file.ContentLength > max )
		return false;
		
	try
	{
		// define our allowed image formats
		var allowedFormats = new[] { ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Gif, ImageFormat.Bmp };
		
		// Creates an Image from the specified data stream.      
		using (var img = Image.FromStream(file.InputStream))
		{
			// Return true if the image format is allowed
			return allowedFormats.Contains(img.RawFormat);
		}
	}
	catch( Exception ex )
	{
		ms.AddModelError( "", ex.Message );					
	}
	return false;	
    }
