       public string ReadPdfFile(string fileName)
                {
                    StringBuilder text = new StringBuilder();
        
                    if (File.Exists(fileName))
                    {
                        PdfReader pdfReader = new PdfReader(fileName);
        
                        for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                        {
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);
        
                            currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                            text.Append(currentText);
                        }
                        pdfReader.Close();
                    }
                    return text.ToString();
                }
                private static string GetFormFieldNames(PdfReader pdfReader)
                {
                    return string.Join("\r\n", pdfReader.AcroFields.Fields
                                                   .Select(x => x.Key).ToArray());
                }
        
                private static string GetFormFieldNamesWithValues(PdfReader pdfReader)
                {
                    return string.Join("\r\n", pdfReader.AcroFields.Fields
                                                   .Select(x => x.Key + "=" +
                                                    pdfReader.AcroFields.GetField(x.Key))
                                                   .ToArray());
                }
                private void Button_Click_1(object sender, RoutedEventArgs e)
                {
                   var reader = new PdfReader(@"Direction_to_your.pdf");
                   AcroFields form = reader.AcroFields;
                   txtBox1.Text = GetFormFieldNamesWithValues(reader); 
                   reader.Close();
                }
