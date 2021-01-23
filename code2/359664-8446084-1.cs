    var request = new DocumentsRequest(settings);
    request.BaseUri = "https://docs.google.com/feeds/default/private/full/folder" + folderResourceId + "/contents";
    Feed<Document> feed = request.GetEverything();
    foreach (Document entry in feed.Entries)
    {
        if (entry.Title == fileName)
        {
            var fI = new FileInfo(uploadpath + entry.Title);
            Stream stream = request.Download(entry, "");
            arr = Read(stream);
            stream.Close();
            break;
         }
    }
    private Byte[] Read(Stream stream)
    {
        //long originalPosition = stream.Position;
        //stream.Position = 0;
        try
        {
            Byte[] readBuffer = new Byte[4096];
            int totalBytesRead = 0;
            int bytesRead;
            while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
            {
                totalBytesRead += bytesRead;
                if (totalBytesRead == readBuffer.Length)
                {
                    int nextByte = stream.ReadByte();
                    if (nextByte != -1)
                    {
                        Byte[] temp = new Byte[readBuffer.Length * 2];
                        Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                        Buffer.SetByte(temp, totalBytesRead, (Byte)nextByte);
                        readBuffer = temp;
                        totalBytesRead++;
                    }
                }
            }
            Byte[] buffer = readBuffer;
            if (readBuffer.Length != totalBytesRead)
            {
                buffer = new Byte[totalBytesRead];
                Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
            }
            return buffer;
        }
        finally
        {
            //stream.Position = originalPosition;
        }
    }
