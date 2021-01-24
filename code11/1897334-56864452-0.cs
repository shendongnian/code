    Bitmap img = null;
    try
    {
        img = new Bitmap(filename);  // Here I simplified the code, but this will leave the file locked until `img` is disposed after resizing.
        
        this.size = img.Size;
        using (var old = img)
            img = ResizeImage(old, 8, 8);
        using (var old = img)
            img = MakeGrayscale(old);
        
        //I do some basic for-loop arithmetic here 
        //calculating the average color of the image, not worth posting.
    }
    finally
    {
        if (img != null)
            img.Dispose();
    }
