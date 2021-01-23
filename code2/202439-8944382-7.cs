    public void Upload(Stream stream)
    {
        HttpMultipartParser parser = new HttpMultipartParser(stream, "image");
	
        if (parser.Success)
        {
            string user = HttpUtility.UrlDecode(parser.Parameters["user"]);
            string title = HttpUtility.UrlDecode(parser.Parameters["title"]);
		
            // Save the file somewhere
            File.WriteAllBytes(FILE_PATH + title + FILE_EXT, parser.FileContents);
        }
    }
