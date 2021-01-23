           // Create the stream
            FileStream stream = new FileStream(
                "D:\\test.dat", 
                FileMode.Create, 
                FileAccess.ReadWrite, 
                FileShare.ReadWrite, 
                8, 
                FileOptions.DeleteOnClose // This is the necessary part for me.
                );
            // Create a file mapping
            MemoryMappedFile x = MemoryMappedFile.CreateFromFile(
                stream,
                "File1", 
                10000000000, 
                MemoryMappedFileAccess.ReadWrite, 
                new MemoryMappedFileSecurity(),
                System.IO.HandleInheritability.None, 
                false
                );
            // Dispose the stream, using the FileOptions.DeleteOnClose the file is gone now
            stream.Dispose();
