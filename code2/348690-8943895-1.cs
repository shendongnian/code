    public void Upload(Stream stream)
    {
        HttpMultipartParser parser = new HttpMultipartParser(data, "image");
	
        if (parser.Success)
        {
            string user = parser.Parameters["user"];
            string title = parser.Parameters["title"];
		
		    // Save the file somewhere
		    File.WriteAllBytes(FILE_PATH + title + FILE_EXT, parser.FileContents);
        }
    }
