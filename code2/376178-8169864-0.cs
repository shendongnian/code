    using (var fs = File.OpenWrite(outputFilename))
    {
        using (var gz = new GZipStream(fs, CompressionMode.Compress))
        {
            // now, write to the GZip stream . . .
            gz.Write(buffer, 0, buffer, length);
        }
    }
