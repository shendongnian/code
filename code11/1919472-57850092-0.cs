    XmlDocument document = new XmlDocument();
    
    if (!System.IO.Directory.Exists(folderPath))
        System.IO.Directory.CreateDirectory(folderPath);
    var filename = folderPath + @"\XMLfile.xml";
    if (System.IO.File.Exists(filename);
        document.Load(filename);
    else
        document.LoadXml("<?xml version=\"1.0\"?> \n" +
                         "<elements> \n" +
                         "</elements>");
    }
