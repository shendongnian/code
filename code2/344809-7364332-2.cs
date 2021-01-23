    private void ReplaceFileStream(string strInputFile)
    {
        string tempFile = Path.GetTempFileName();
        try
        {
            using(FileStream input = new FileStream(strInputFile,
                FileMode.Open, FileAccess.Read))
            using(FileStream output = new FileStream(tempFile,
                FileMode.Create, FileAccess.Write))
           {
               byte[] buffer = new byte[4096];
               bytesRead = input.Read(buffer, 0, 4096);
               while(bytesRead > 0)
               {
                    for(int i=0; i < bytesRead; ++i)
                    {
                        if (buffer[i] == 0x0D)
                        {
                            buffer[i] = 0x20;
                        }
                    }
                        
                    output.Write(buffer, 0, bytesRead);
                    bytesRead = input.Read(buffer, 0, 4096);
                }
                output.Flush();
            }
              
            File.Copy(tempFile, strInputFile);
        }
        finally
        {
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
    }
