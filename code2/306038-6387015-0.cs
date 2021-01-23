            byte[] completedDocument = null;
            using (MemoryStream streamCompleted = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    PdfCopy copy = new PdfCopy(document, streamCompleted);
                    document.Open();
                    copy.Open();
                    foreach (var item in eventItems)
                    {
                        byte[] mergedDocument = null;
                        PdfReader reader = new PdfReader(pdfTemplates[item.DataTokens[NotifyTokenType.OrganisationID]]);
                        using (MemoryStream streamTemplate = new MemoryStream())
                        {
                            using (PdfStamper stamper = new PdfStamper(reader, streamTemplate))
                            {
                                foreach (var token in item.DataTokens)
                                {
                                    if (stamper.AcroFields.Fields.Any(fld => fld.Key == token.Key.ToString()))
                                    {
                                        stamper.AcroFields.SetField(token.Key.ToString(), token.Value);
                                    }
                                }
                                stamper.FormFlattening = true;
                                stamper.Writer.CloseStream = false;
                            }
                            //Copy the stream's bytes
                            mergedDocument = streamTemplate.ToArray();
                        }
                        reader = new PdfReader(mergedDocument);
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            document.SetPageSize(PageSize.A4);
                            copy.AddPage(copy.GetImportedPage(reader, i));
                        }
                        //Close the document and the copy
                        document.Close();
                        copy.Close();
                    }
                    //ToArray() can operate on closed streams
                    completedDocument = streamCompleted.ToArray();
                }
            }
            return completedDocument;
