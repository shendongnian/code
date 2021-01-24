    void certainMethod()
    {
       using var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(serviceKey);
       using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
       resource?.CopyTo(file);
    }
     
