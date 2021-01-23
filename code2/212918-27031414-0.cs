    private string AddWaterMarkPageToFile(string fileName, string userComments)
            {
                string outputFileName = Path.GetTempFileName() + ".pdf";
                //Step 1: Create a Docuement-Object
                Document document = new Document();
                try
                {
                    //Step 2: we create a writer that listens to the document
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outputFileName, FileMode.Create));
    
                    //Step 3: Open the document
                    document.Open();
    
                    PdfContentByte cb = writer.DirectContent;
    
                    //The current file path
                    string filename = fileName;
    
                    // we create a reader for the document
                    PdfReader reader = new PdfReader(filename);
    
                    for (int pageNumber = 1; pageNumber < reader.NumberOfPages + 1; pageNumber++)
                    {
                        document.SetPageSize(reader.GetPageSizeWithRotation(1));
                        document.NewPage();
    
                        //Insert to Destination on the first page
                        if (pageNumber == 1)
                        {
                            Chunk fileRef = new Chunk(" ");
                            fileRef.SetLocalDestination(filename);
                            document.Add(fileRef);
                        }
    
                        PdfImportedPage page = writer.GetImportedPage(reader, pageNumber);
                        int rotation = reader.GetPageRotation(pageNumber);
                        if (rotation == 90 || rotation == 270)
                        {
                            cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(pageNumber).Height);
                        }
                        else
                        {
                            cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                        }
                    }
    
                    // Add a new page to the pdf file
                    document.NewPage();
    
                    float fontSize = 80;
                    float xPosition = iTextSharp.text.PageSize.A4.Width / 2;
                    float yPosition = (iTextSharp.text.PageSize.A4.Height - 140f) / 2;
                    float angle = 45;
    
                    PdfContentByte under = writer.DirectContentUnder;
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                    under.BeginText();
                    under.SetColorFill(BaseColor.LIGHT_GRAY);
                    under.SetFontAndSize(baseFont, fontSize);
                    under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, userComments, xPosition, yPosition, angle);
                    under.EndText();
                                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    document.Close();
                }
                return outputFileName;
            }
