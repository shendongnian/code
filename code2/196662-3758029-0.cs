    // Open the file
    using (var file = File.Open(...))
    {
        // Move to the relevant place in the file where the piece begins
        file.Seek(piece * pieceLength, SeekOrigin.Begin);
    
        // Attempt to read up to pieceLength bytes from the file into a buffer
        byte[] buffer = new byte[pieceLength];
        int totalRead = 0;
        while (totalRead < pieceLength)
        {
            var read = stream.Read(buffer, totalRead, pieceLength-totalRead);
            if (read == 0)
            {
                // the piece is smaller than the pieceLength,
                // because it’s the last in the file
                Array.Resize(ref buffer, totalRead);
                break;
            }
            totalRead += read;
        }
    
        // If you want the raw data for the piece:
        return buffer;
    
        // If you want the SHA1 hashsum:
        return SHA1.Create().ComputeHash(buffer);
    }
