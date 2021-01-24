    public void Viewer(View_Firma firma)
            {
                string subfoldername = "App_Data";
                //Your fileName
                string filename = "test.docx";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);
    
    
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
                {
    
                
                    IDictionary<String, BookmarkStart> bookmarkMap =
                              new Dictionary<String, BookmarkStart>();
    
                    foreach (BookmarkStart bookmarkStart in wordDoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
                    {
                        System.Diagnostics.Debug.WriteLine(bookmarkStart.Name);
                        if (bookmarkStart.Name == "Plz")
                        {
                            System.Diagnostics.Debug.WriteLine("test");
                            FirmaCreateEditController.InsertIntoBookmark(bookmarkStart, firma.Plz);
                        }
             
                        if (bookmarkStart.Name == "Blz")
                        {
                            FirmaCreateEditController.InsertIntoBookmark(bookmarkStart, firma.Blz);
                        }
    
    
                    }
                    
                }
    
                FileInfo file = new FileInfo(path);
    
                if (file.Exists)
                {
    
                    Response.ContentType = "application/msword";
                    Response.AddHeader("Content-Disposition", "Attachment; filename=\"Firma.doc\"");
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.TransmitFile(file.FullName);
                }
                
            }
