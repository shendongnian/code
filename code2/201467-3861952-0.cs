    var validExtensions = new [] { ".png", ".jpg", /* etc */ };
    var lst = (IEnumerable<string>) e.Data.GetData(DataFormats.FileDrop);
    foreach (var ext in lst.Select((f) => System.IO.Path.GetExtension(f)))
    {
        if (!validExtensions.Contains(ext))
            return false;  
    }
    return true;
