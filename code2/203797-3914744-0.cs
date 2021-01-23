        using (FileStream stream = File.OpenRead("C:\\file1.txt"))
        using (FileStream writeStream = File.OpenWrite("D:\\file2.txt"))
        {
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(writeStream);
            // create a buffer to hold the bytes 
            byte[] buffer = new Byte[1024];
            int bytesRead;
            // while the read method returns bytes
            // keep writing them to the output stream
            while ((bytesRead =
                    stream.Read(buffer, 0, 1024)) > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
            }
        }
