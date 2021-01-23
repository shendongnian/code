    //Backup
    var lBackup = new Dictionary<string, object>();
    var lDataObject = Clipboard.GetDataObject();
    var lFormats = lDataObject.GetFormats(false);
    foreach(var lFormat in lFormats)
    {
      lBackup.Add(lFormat, lDataObject.GetData(lFormat, false));
    }
    
    //Set test data
    Clipboard.SetText("asd");
    //Would be interesting to check the contents of lDataObject here
    
    //Restore data
    foreach(var lFormat in lFormats)
    {
      lDataObject.SetData(lBackup[lFormat]);
    }
    //This might be unnecessary
    Clipboard.SetDataObject(lDataObject);
