    var path = LogFilePath();
    if (string.IsNullOrWhiteSpace(path))
    {
        return;
    }
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
    using (StreamWriter sw = File.AppendText(path))
    {
         Log1(destinationfilepath, attachmentname, sw);
    }
    
