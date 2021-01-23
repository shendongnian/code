    byte[] chunk = new byte[MaxChunkSize];
    while (true)
    {
        int index = 0;
        // There are various different ways of structuring this bit of code.
        // Fundamentally we're trying to keep reading in to our chunk until
        // either we reach the end of the stream, or we've read everything we need.
        while (index < chunk.Length)
        {
            int bytesRead = stream.Read(chunk, index, chunk.Length - index);
            if (bytesRead == 0)
            {
                break;
            }
            index += bytesRead;
        }
        if (index != 0) // Our previous chunk may have been the last one
        {
            SendChunk(chunk, index); // index is the number of bytes in the chunk
        }
        if (index != chunk.Length) // We didn't read a full chunk: we're done
        {
            return;
        }
    }
