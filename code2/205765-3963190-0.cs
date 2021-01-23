    // loop over document pages 
    //was (int i = 0; i < pages; i++) {
    for (int i = 1; i < pages; i++) {
        page = copy.GetImportedPage(new PdfReader(p), i);
        stamp = copy.CreatePageStamp(page);
        PdfContentByte cb = stamp.GetUnderContent();
        cb.SaveState();
        stamp.AlterContents();
        copy.AddPage(page);
    }
