     using (WordprocessingDocument wordProcessingDocument = WordprocessingDocument.Open(input, true))
                    {
                        // Get all content control elements
                        List<DocumentFormat.OpenXml.OpenXmlElement> elements =
                            wordProcessingDocument.MainDocumentPart.Document.Body.ToList();
                        // Get and set the style properties of each content control
                        foreach (var itm in elements)
                        {
                            try
                            {
                                List<RunProperties> list_runProperties = 
                                      itm.Descendants<RunProperties>().ToList();
                                foreach (var item in list_runProperties)
                                {
                                    if (item.RunFonts == null)
                                        item.RunFonts = new RunFonts();
                                    item.RunFonts.Ascii = "Courier New";
                                    item.RunFonts.ComplexScript = "Courier New";
                                    item.RunFonts.HighAnsi = "Courier New";
                                    item.RunFonts.Hint = FontTypeHintValues.ComplexScript;
                                }
                            }
                            catch (Exception)
                            {
                                //continue for other tags in document 
                                //throw;
                            }
                        }
                        wordProcessingDocument.MainDocumentPart.Document.Save();
                    }
