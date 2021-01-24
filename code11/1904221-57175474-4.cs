     void certainMethod()
        {
           using var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(serviceKey);
           using var file = new FileStream(path, FileMode.Create, FileAccess.Write);
           resource?.CopyTo(file);
           using var oneMoreFile = new FileStream(path, FileMode.Create, FileAccess.Write);
           //This will fail
           resource?.CopyTo(oneMoreFile );
        }
