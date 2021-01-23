            PdfReader originalPDFReader = new PdfReader(pdfByteArray);
            using (MemoryStream msCopy = new MemoryStream())
            {
               using (Document docCopy = new Document())
               {
                  using (PdfCopy copy = new PdfCopy(docCopy, msCopy))
                  {
                     docCopy.Open();
                     for (int pageNum = 1; pageNum <= originalPDFReader.NumberOfPages - 1; pageNum ++)
                     {
                        copy.AddPage(copy.GetImportedPage(originalPDFReader, pageNum ));
                     }
                     docCopy.Close();
                  }
               }
               pdfByteArray = msCopy.ToArray();
