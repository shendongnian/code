    public static void Concatenate(string outputFile, IEnumerable<string> sourceFiles)
    {
        byte[] buffer = new byte[1024];
        WaveFileWriter waveFileWriter = null;
        try
        {
            foreach (string sourceFile in sourceFiles)
            {
                using (WaveFileReader reader = new WaveFileReader(sourceFile))
                {
                    if (waveFileWriter == null)
                    {
                        // first time in create new Writer
                        waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
                    }
                    else
                    {
                        if (reader.WaveFormat != waveFileWriter.WaveFormat)
                        {
                            throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
                        }
                    }
                    int read;
                    while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        waveFileWriter.WriteData(buffer, 0, read);
                    }
                }
            }
        }
        finally
        {
            if (waveFileWriter != null)
            {
                waveFileWriter.Dispose();
            }
        }
    }
