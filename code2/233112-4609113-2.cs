    if (path.StartsWith("\\\\\\\\") || path.Contains(":"))
    {
       // Problem was that in TextBox were really 4 backslashes so it jumps here
       image.Save(path,ImageFormat.Png); 
       // and because string started as "\\\\" it throws GDI+ error
    }
    else
    {
       string path2= Directory.GetCurrentDirectory()+"\\"+path;
       image.Save(path2, System.Drawing.Imaging.ImageFormat.Png);
    }
