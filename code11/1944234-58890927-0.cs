    var document = new PdfDocument();
    var page = document.AddPage();
    var gfx = XGraphics.FromPdfPage(page);
    page.Width = XUnit.FromMillimeter(111);
    page.Height = XUnit.FromMillimeter(222);
    //some logic to create multiple pages
     document.Save("C:\mydoc\");
    PdfDocument finalOutputDocument;
            if (CopyCount >1)
            {
                MemoryStream stream = new MemoryStream();
                document.Save(stream, false);
                PdfDocument source = PdfReader.Open(stream, PdfDocumentOpenMode.Import);
                finalOutputDocument= new PdfDocument();
                for (int i = 0; i < CopyCount; i++)
                {
                    for (int k = 0; k < document.Pages.Count; k++)
                    {
                        finalOutputDocument.Pages.Add(source.Pages[k]);
                    }
                }
            }
            else
            {
                finalOutputDocument= document;
            }
            finalOutputDocument.Save(path);
