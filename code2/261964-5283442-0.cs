    //Get the assembly.
    System.Reflection.Assembly CurrAssembly = System.Reflection.Assembly.LoadFrom(System.Windows.Forms.Application.ExecutablePath);
    
    //Gets the image from Images Folder.
    System.IO.Stream stream = CurrAssembly.GetManifestResourceStream("ImageURL");
    
    if (null != stream)
    {
        //Fetch image from stream.
        MyShortcut.IconLocation = System.Drawing.Image.FromStream(stream);
    }
