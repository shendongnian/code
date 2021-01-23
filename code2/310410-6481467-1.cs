    using (var mmf = MemoryMappedFile.CreateFromFile(filename,
                       System.IO.FileMode.OpenOrCreate,
                       "myMap" + fileNo.ToString(), fileSize))
    {
        using (reader = mmf.CreateViewAccessor(0, accessorSize))
        {  
           ... <do stuff> ...
        }
    }
    File.Delete(filename);
