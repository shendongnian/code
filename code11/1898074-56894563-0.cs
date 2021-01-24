    var tfile = TagLib.File.Create(@"..");
    string initialKey = null;
    
    if (tfile.GetTag(TagTypes.Id3v2) is TagLib.Id3v2.Tag id3v2)
    {
        /*
        // test: add custom Initial Key tag 
        var frame = TextInformationFrame.Get(id3v2, "TKEY", true);
        frame.Text = new[] {"qMMM"};
        frame.TextEncoding = StringType.UTF8;
        tfile.Save();
        */
    
        var frame = TextInformationFrame.Get(id3v2, "TKEY", false);			
        initialKey = frame?.ToString();
    }
