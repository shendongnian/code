    if (file.PostedFile != null)
    {
        //write the new file to disk
        string cachePath = String.Format("{0}temp\\", Request.PhysicalApplicationPath);
        string photoPath = String.Format("{0}temp.png", cachePath);                
        if (!Directory.Exists(cachePath))
    {
       Directory.CreateDirectory(cachePath);
    }    
    file.PostedFile.SaveAs(photoPath);
     
    //resize the new file and save it to disk               
    BitmapSource banana = FitImage(ReadBitmapFrame(file.PostedFile.InputStream), 640, 480);
    PngBitmapEncoder encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(banana));
    FileStream pngStream = new FileStream(cachePath + "test.png", FileMode.Create);
    encoder.Save(pngStream);
    pngStream.Close();
    //set a couple images on page to the newly uploaded and newly processed files
    image.Src = "temp/temp.png";
    image.Visible = true;
    image2.Src = "temp/test.png"; 
 
       image2.Visible = true;
    }
