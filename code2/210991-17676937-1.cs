            public static void MergeTwoPdfsToSingle(string inputFile1, string inputFile2, string outputFile)
        {
            //Step 1: Create a Docuement-Object
            Document document = new Document();
            try
            {
                //Step 2: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFile, FileMode.Create));
                //Step 3: Open the document
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page1;
                PdfImportedPage page2;                
                // we create a reader for the document
                PdfReader reader1 = new PdfReader(inputFile1);
                PdfReader reader2 = new PdfReader(inputFile2);
                document.SetPageSize(reader1.GetPageSizeWithRotation(1));
                document.NewPage();
                page1 = writer.GetImportedPage(reader1, 1);                                
                page2 = writer.GetImportedPage(reader2, 1);                
                cb.AddTemplate(page1, 0, 0);
                //play around to find the exact location for the next pdf
                cb.AddTemplate(page2, 0, 300);
            }
            catch (Exception e) { throw e; }
            finally { document.Close(); }
        }
