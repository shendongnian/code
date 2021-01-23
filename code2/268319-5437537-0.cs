    using (TextWriter tw = new StreamWriter(oRequest.GetRequestStream()))
    {
        tw.Write(strHead);
        var tempPath = Path.GetTempFileName();
        try
        {
            using (var input = File.OpenRead(strPath))
            using (var output = File.Open(
                tempPath, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamEncode(fileStream, output);
                output.Seek(0, SeekOrigin.Begin);
                CopyTo(output, ((StreamWriter)tw).BaseStream);
            }
        }
        finally
        {
            File.Delete(tempPath);
        }
        tw.Write(strTail);
    }
    
    public void StreamEncode(Stream inputStream, Stream output)
    {
        // For Base64 there are 4 bytes output for every 3 bytes of input
        byte[] base64Block = new byte[9000];
        int bytesRead = 0;
        string base64String = null;
    
        using (var tw = new StreamWriter(output))
        {
            do
            {
                // read one block from the input stream
                bytesRead = inputStream.Read(base64Block, 0, base64Block.Length);
    
                // encode the base64 string
                base64String = Convert.ToBase64String(base64Block, 0, bytesRead);
    
                // write the string
                tw.Write(base64String);
    
            } while (bytesRead !=0 );
        }
    
    }
    
    
    static void CopyTo(Stream input, Stream output)
    {
        const int length = 10240;
        byte[] buffer = new byte[length];
        int count = 0;
    
        while ((count = input.Read(buffer, 0, length)) > 0)
            output.Write(buffer, 0, count);
    }
