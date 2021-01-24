#if ENABLE_WINMD_SUPPORT
        var objectPath = KnownFolders.Objects3D.Path;
        string path = Path.Combine(objectPath, "MyFile.txt");
        string targetPath = Path.Combine(Application.persistentDataPath, "MyFile.txt");
        using (TextWriter writer = File.CreateText(path))
        {
            writer.WriteLine("test");
        }
        File.Move( path, targetPath);
#endif
 
