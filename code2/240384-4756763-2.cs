    ImageCodecInfo iciJpegCodec = null;
    // This will specify the image quality to the encoder. Change the value of 75 from 0 to 100, where 100 is best quality, but highest file size.
    EncoderParameter epQuality = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 75);
    // Get all image codecs that are available
    ImageCodecInfo[] iciCodecs = ImageCodecInfo.GetImageEncoders();
    // Store the quality parameter in the list of encoder parameters
    EncoderParameters epParameters = new EncoderParameters(1);
    epParameters.Param[0] = epQuality;
 
    // Loop through all the image codecs
    for (int i = 0; i < iciCodecs.Length; i++)
    {
        // Until the one that we are interested in is found, which is image/jpeg
        if (iciCodecs[i].MimeType == "image/jpeg")
        {
            iciJpegCodec = iciCodecs[i];
            break;
        }
    }
 
    // Create a new Image object from the current file
    Image newImage = Image.FromFile(strFile);
 
    // Get the file information again, this time we want to find out the extension
    FileInfo fiPicture = new FileInfo(strFile);
    // Save the new file at the selected path with the specified encoder parameters, and reuse the same file name
    newImage.Save(outputPath + "\\" + fiPicture.Name, iciJpegCodec, epParameters);
