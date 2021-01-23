        using (var dataFile = new System.IO.BinaryReader(System.IO.File.OpenRead("yourfile.dat")))
        {
            try
            {
                // Parse your data file according to the known format.
                dataFile.ReadBoolean();
                dataFile.ReadInt32();
                // ...and so on.
            }
            catch(System.IO.EndOfStreamException e)
            {
                // Handle trying to read past the end of the stream
            }
        }
