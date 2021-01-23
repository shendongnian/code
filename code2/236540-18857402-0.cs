    fax.Attachments.Add(@"C:\\Test Attachments\\Products.pdf", BoolType.False);
    fax.Attachments.Item(1).AttachmentType = AttachmentType.aFile;
    fax.Send();
    fax.StoreAsNewLibraryDocument("PRODUCTS", "The Products");
    server.LibraryDocuments("PRODUCTS").IsPublishedForWeb = BoolType.True;
