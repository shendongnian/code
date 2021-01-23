    using (var isFile = IsolatedStorageFile.GetUserStoreForApplication())
    {
        XDocument loadedDoc;
        using (var stream = isFile.OpenFile("/Items.xml", FileMode.Open))
        {
           loadedDoc = XDocument.Load(stream);
        }
        loadedDoc.Add(newItem); 
        using (var stream = isFile.OpenFile("/Items.xml", FileMode.Create))
        {
           loadedDoc.Save(stream);
        } 
    }
