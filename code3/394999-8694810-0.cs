    bytesSize = fs.Read(UpBuffer, 0, UpBuffer.Length);
    while ((bytesSize = fs.Read(UpBuffer, 0, UpBuffer.Length)) > 0)
    {
        StatusUp[0] = StatusUp[0] + UpBuffer.Length;
        // etc..
    }
