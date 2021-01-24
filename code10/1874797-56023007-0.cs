    using (var fs = new FileStream(HttpContext.Current.Server.MapPath(outputFilepath),FileMode.Create))
    {
        using (var document = new Document())
        {
            using (var pdfCopy = new PdfCopy(document, fs))
            {
                document.Open();
                for (var i = 0; i < numberOfFilesToMerge; i++)
                {
                    using (var pdfReader = new PdfReader(sourceFiles[i]))
                    {
                        for (var page = 0; page < pdfReader.NumberOfPages;)
                        {
                            pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, ++page));
                        }
                    }
                }
            }
         }
     }
