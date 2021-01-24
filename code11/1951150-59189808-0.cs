    static void Main(string[] args)
    {
        // Try with Read here and Read on your create view to see if anything changes
        FileStream fs = new FileStream("programe.exe", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
        // Set the length of the file here.
        MemoryMappedFile memory = MemoryMappedFile.CreateFromFile(fs, "mapname", fs.Length, MemoryMappedFileAccess.ReadExecute,null,0,false);
        MemoryMappedViewAccessor mmr = memory.CreateViewAccessor(0, fs.Length, MemoryMappedFileAccess.Read);
        Console.ReadKey();
    }
