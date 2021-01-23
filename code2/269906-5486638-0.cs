        public static bool MergeFiles2(string destinationFile, List<string> sourceFiles)
        {
            try
            {
                //Phase 1: merging multiple files
                int f = 0;
                // we create a reader for a certain document
                PdfReader reader = new PdfReader(sourceFiles[f]);
                // we retrieve the total number of pages
                int n = reader.NumberOfPages;                 
                // step 1: creation of a document-object
                Document document = new Document(reader.GetPageSizeWithRotation(1));
                // step 2: we create a Memorystream for manipulating the files in memory
                MemoryStream ms = new MemoryStream();
                // step 3: we create a writer that listens to the document
                PdfWriter writer = PdfWriter.GetInstance(document, ms);       
                // step 4: we open the document
                document.Open();
                
                PdfContentByte cb = writer.DirectContent;                
                PdfImportedPage page;
                
                int rotation;
                // step 4: we add content
                while (f < sourceFiles.Count)
                {
                    int i = 0;
                    while (i < n)
                    {
                        i++;
                        document.SetPageSize(reader.GetPageSizeWithRotation(i));
                        document.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        rotation = reader.GetPageRotation(i);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                    }
                    f++;
                    if (f < sourceFiles.Count)
                    {
                        reader = new PdfReader(sourceFiles[f]);
                        // we retrieve the total number of pages
                        n = reader.NumberOfPages;
                    }
                }
                //step 5: we close the document
                document.Close();
                //step 6: we pass the stream into an array for passing all to an instance of PdfReader
                byte[] content = ms.ToArray();
                //Phase 2: Adding content to merged files
                
                //Step 1: we create an instance of PdfReader that reads the content of the last MemoryStream used
                PdfReader reader2 = new PdfReader(content);
                //Step2: we create a new MemoryStream
                MemoryStream ms2 = new MemoryStream();
                //Step3: we create a PdfStamper with the last PdfReader and the last MemoryStream created
                PdfStamper stamper = new PdfStamper(reader2, ms2);
                //Step4: for each page of the merged PDF we add the index of the page on the left and with orientation vertical
                for (int i = 1; i <= reader2.NumberOfPages; i++)
                {
                    PdfContentByte canvas = stamper.GetOverContent(i);
                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, new Phrase("Page " + i + " of " + reader2.NumberOfPages), 10, 350, 90);
                }
                //Step5: we close the stamper
                stamper.Close();
                //Step6: we convert the MemoryStream to an array of bytes
                byte[] content2 = ms2.ToArray();
                
                //Step7: we finalize all creating the resultant file on the filesystem
                using (FileStream fs = File.Create(destinationFile))
                { 
                    fs.Write(content2, 0, (int)content2.Length); 
                }
                
                MessageBox.Show("I file PDF sono stati uniti correttamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
