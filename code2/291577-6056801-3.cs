    public static void CombineMultiplePDFs(string[] fileNames, string outFile)
    {
        // step 1: creation of a document-object
        Document document = new Document();
        // step 2: we create a writer that listens to the document
        PdfCopy writer = new PdfCopy(document, new FileStream(outFile, FileMode.Create));
        if (writer == null)
        {
            return;
        }
        // step 3: we open the document
        document.Open();
        foreach (string fileName in fileNames)
        {
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(fileName);
            reader.ConsolidateNamedDestinations();
            // step 4: we add content
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {                
                PdfImportedPage page = writer.GetImportedPage(reader, i);
                writer.AddPage(page);
            }
            PRAcroForm form = reader.AcroForm;
            if (form != null)
            {
                writer.CopyAcroForm(reader);
            }
            reader.Close();
        }
        // step 5: we close the document and writer
        writer.Close();
        document.Close();
    }
        
