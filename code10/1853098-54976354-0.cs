    int read = stream.Read(buffer, 0, 4);
    int imageSize = BitConverter.ToInt32(buffer, 0);
    int bytesRead, totalBytesRead = 0;
    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
    {
         totalBytesRead += bytesRead;
         if(totalBytesRead == imageSize)
         {
             //Save image
         }
         else if(totalBytesRead > imageSize)
         {
             //May happens, split the buffer.
         }
    }
