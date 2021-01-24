    mmf = MemoryMappedFile.OpenExisting(filePath);
    using (var accessor = mmf.CreateViewAccessor(0, Marshal.SizeOf(typeof(int)) * 5))
    {
        int intSize = Marshal.SizeOf(typeof(int));
        //Read first array..
        for (long i = 0; i < 3 * intSize; i += intSize)
        {
            int value = 0;
            accessor.Read(i, out value);
            firstArray[i] = value;
        }
    
        //Read second array..
        for (long i = 0; i < 2 * intSize; i += intSize)
        {
            int value = 0;
            accessor.Read(i, out value);
            secondArrayArray[i] = value;
        }
    }
