    GDPictureScanning scanner = new GDPictureScanning();
            
    IEnumerable<Page> pages = scanner.AquireImages();
    foreach (Page page in pages)
    {
    m_DocumentModel.AddPage(page);                
    //The view gets notified of new pages via events raised by the model
    //The events are subscribed to by the various presenters so they can 
    //update views accordingly                
    }
