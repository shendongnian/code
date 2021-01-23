    foreach (XElement  pic in neededFiles.Elements())
    {
        unSyncedPictures.Add(pic.Value);
    }
    List<string> temp = new List<string>();
    temp.AddRange(unSyncedPictures.Distinct());
