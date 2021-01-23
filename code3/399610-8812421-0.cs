    int chunkSize = 2048;
    byte[] buffer = new byte[chunkSize];
    
    using (System.IO.FileStream writeStream =
        new System.IO.FileStream(file.FullName, System.IO.FileMode.CreateNew, System.IO.FileAccess.Write))
    {
        do
        {
            // read bytes from input stream
            int bytesRead = request.FileByteStream.Read(buffer, 0, chunkSize);
            if (bytesRead == 0) break;
    
            // write bytes to output stream
            writeStream.Write(buffer, 0, bytesRead);
        } while (true);
    
        writeStream.Close();
    }
