    TagLib.Id3v2.Tag id3v2tag = tagFile.GetTag(TagLib.TagTypes.Id3v2, false);
    
    if(id3v2tag != null)
        id3v2tag.Version = 3;
    
    tagFile.Save();
