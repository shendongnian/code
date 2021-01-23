    using(StreamReader batchReader = new StreamReader("path to batch file"))
    {
        string batchCommand;
        while(!batchReader.EndOfStream)
        {
            batchCommand = batchReader.ReadLine();
            // do your processing with batch command
        }
    }
