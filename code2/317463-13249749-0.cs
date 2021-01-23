    private static void AppendToDocument(string sourcePdfPath1, string sourcePdfPath2, string outputPdfPath)
    {
        using (var sourceDocumentStream1 = new FileStream(sourcePdfPath1, FileMode.Open))
        {
            using (var sourceDocumentStream2 = new FileStream(sourcePdfPath2, FileMode.Open))
            {
                using (var destinationDocumentStream = new FileStream(outputPdfPath, FileMode.Create))
                {
                    var pdfConcat = new PdfConcatenate(destinationDocumentStream);
                    var pdfReader = new PdfReader(sourceDocumentStream1);
                    var pages = new List<int>();
                    for (int i = 0; i < pdfReader.NumberOfPages; i++)
                    {
                        pages.Add(i);
                    }
                    pdfReader.SelectPages(pages);
                    pdfConcat.AddPages(pdfReader);
                    pdfReader = new PdfReader(sourceDocumentStream2);
                    pages = new List<int>();
                    for (int i = 0; i < pdfReader.NumberOfPages; i++)
                    {
                        pages.Add(i);
                    }
                    pdfReader.SelectPages(pages);
                    pdfConcat.AddPages(pdfReader);
                    pdfReader.Close();
                    pdfConcat.Close();
                }
            }
        }
    }
