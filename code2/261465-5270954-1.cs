    int size = 10 * 1024;
    using (Stream stream = file.OpenBinaryStream())
    {
      using (FileStream fs = new FileStream(@"C:\Users\krg\Desktop\xyz.pptx", FileMode.Create, FileAccess.Write))
      {
        byte[] buffer = new byte[size];
        int bytesRead;
        while((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
          fs.Write(buffer, 0, bytesRead);
        }
      }
    }
