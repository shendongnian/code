    public static Bitmap GetLibraryObjectImage(Guid guid) 
    { 
       Bitmap bitmap = null;
       
       try
       { 
          string tempPath = GetLibraryObjectImagePath(guid); 
          if (!String.IsNullOrEmpty(tempPath) 
          {
             using (var stream = File.OpenRead(tempPath))
             {
                bitmap = (Bitmap)Image.FromStream(stream);
             }
          } 
       } 
       catch
       { 
          bitmap = (Bitmap)Image.FromFile(Application.StartupPath + @"\na.bmp"); 
       }
       
       if (bitmap == null)
       {
          bitmap = (Bitmap)Image.FromFile(Application.StartupPath + @"\na.bmp"); 
       }
    
       return bitmap;
    } 
