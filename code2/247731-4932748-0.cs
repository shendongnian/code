    int maxFrames=32;
    ImageMagickObject.MagickImage imgLarge = new ImageMagickObject.MagickImage();  
    
    // first extract all frames from gif to single png files
    for(int frame=0; frame<maxFrames;frame++)
    {
       object[] o = new object[] { String.Format(strOrig+"[{0}]", frame)
           ,  String.Format("tmp{0}.png", frame) };
       imgLarge.Convert(ref o);    
    }
    // resize every single png files
    // add resized filenames to stringbuilder
    StringBuilder filenames = new StringBuilder();
    for(int frame=0; frame<maxFrames;frame++)
    {
       object[] o = new object[] { String.Format("tmp{0}.png", frame)
                    , "-resize"
                    , size 
                    , "-gravity"
                    , "center"
                    , "-colorspace"
                    , "RGB"
                    , "-extent"
                    , "1024x768"
                    , String.Format("tmp-resized{0}.png", frame) };
       filenames.Append(String.Format("tmp-resized{0}.png", frame));
       filenames.Append(Environment.NewLine);
       imgLarge.Convert(ref o);    
    }
    // write resized filenames to file
    File.WriteAllText("tmp-resized-files.txt", filenames);
    // create resize animated gif based on filenames in the tmp-resized-files.txt
       object[] o = new object[] { "@tmp-resized-files.txt"
           ,  strDestNw };
       imgLarge.Convert(ref o);    
