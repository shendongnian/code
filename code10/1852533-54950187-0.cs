     foreach (PdfReader reader in readerList)
                {                   
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        string totalValue = pdfName[nextOne].ToString();
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                      
                        if (totalValue == "Permit")
                        {
                            PdfContentByte cb = writer.DirectContent;
                            var rect = new iTextSharp.text.Rectangle(200, 200, 100, 100);
                            rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                            rect.BorderWidth = 5; rect.BorderColor = new BaseColor(2, 3, 0);
                            cb.Rectangle(rect);
                        }
                        if (totalValue == "TaxBill")
                        {
                            PdfContentByte cb = writer.DirectContent;
                            var rect = new iTextSharp.text.Rectangle(200, 200, 100, 100);
                            rect.Border = iTextSharp.text.Rectangle.LEFT_BORDER | iTextSharp.text.Rectangle.RIGHT_BORDER;
                            rect.BorderWidth = 15; rect.BorderColor = new BaseColor(3, 2, 0);
                            cb.Rectangle(rect);
                        }
                        nextOne = nextOne + 1;
                        document.Add(iTextSharp.text.Image.GetInstance(page));
                    }
                }
