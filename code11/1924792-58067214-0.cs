    var currentItem = this.Base.Item.Current;
    List<string> links = new List<string>();
    if (currentItem!=null)
    {
        var fileAttachments = PXNoteAttribute.GetFileNotes(this.Base.Item.Cache, currentItem);
        foreach (Guid fileId in fileAttachments)
        {
            links.Add("SITE_URL/INSTANCE_NAME" + "/Frames/GetFile.ashx?fileID=" + fileId);
        }
    }
