    const int MAX_BUFFER = 1024;
    byte[] Buffer = new byte[MAX_BUFFER];
    int BytesRead;
    using (System.IO.FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        while ((BytesRead = fileStream.Read(Buffer, 0, MAX_BUFFER)) != 0)
        {
            // Process this chunk starting from offset 0 
            // and continuing for bytesRead bytes!
        }
