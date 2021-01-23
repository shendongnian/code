    using (var inputStream = File.OpenRead(@"C:\file1.txt"))
    {
        using (var outputStream = File.OpenWrite(@"D:\file2.txt"))
        {
            int bufferLength = 128;
            byte[] buffer = new byte[bufferLength];
            int bytesRead = 0;
    
            do
            {
                bytesRead = inputStream.Read(buffer, 0, bufferLength);
                outputStream.Write(buffer, 0, bytesRead);
            }
            while (bytesRead != 0);
        }
    }
