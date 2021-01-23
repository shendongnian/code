    public void Upload(Stream stream)
    {
        MultipartParser parser = new MultipartParser(stream);
        if (parser.Success)
        {
            // Save the file
            SaveFile(parser.Filename, parser.ContentType, parser.FileContents);
        }
    }
