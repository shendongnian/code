    public static void CombineMultiplePDFs(string[] fileNames, string outFile)
        {
            int pageOffset = 0;
            int f = 0;
            Document document = null;
            PdfCopy writer = null;
            while (f < fileNames.Length)
            {
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(fileNames[f]);
                reader.ConsolidateNamedDestinations();
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;
                pageOffset += n;
                if (f == 0)
                {
                    // step 1: creation of a document-object
                    document = new Document(reader.GetPageSizeWithRotation(1));
                    // step 2: we create a writer that listens to the document
                    writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
                    // step 3: we open the document
                    document.Open();
                }
                // step 4: we add content
                for (int i = 0; i < n; )
                {
                    ++i;
                    if (writer != null)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        writer.AddPage(page);
                    }
                }
                PRAcroForm form = reader.AcroForm;
                if (form != null && writer != null)
                {
                    writer.CopyAcroForm(reader);
                }
                f++;
            }
            // step 5: we close the document
            if (document != null)
            {
                document.Close();
            }
        }
        
