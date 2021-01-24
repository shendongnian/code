    public static void Main(string[] args)
	{
		var path = …
		var file = TagLib.File.Create (path);
		var id3tag = (TagLib.Id3v2.Tag)file.GetTag (TagTypes.Id3v2);
		var key = ReadInitialKey (id3tag);
		Console.WriteLine ("Key = " + key);
	}
    
    static string ReadInitialKey(TagLib.Id3v2.Tag id3tag)
    {
        var frame = id3tag.GetFrames<TextInformationFrame>().Where (f => f.FrameId == "TKEY").FirstOrDefault();
        return frame.Text.FirstOrDefault() ;
    }
