            string template = File.ReadAllText(@"C:\my_template.html");
            var htmlText = Engine.Razor.RunCompile(template, Guid.NewGuid().ToString(), model: GetViewModel());
            TextReader reader = new StringReader(htmlText);
            var document = new Document(PageSize.A4, 30, 30, 30, 30);
            using (var stream = new MemoryStream())
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                var pages = HTMLWorker.ParseToList(reader, new StyleSheet());
                foreach (var page in pages)
                {
                    if (page is PdfPTable)
                    {
                        (page as PdfPTable).SplitLate = false;
                    }
                    document.Add(page as IElement);
                }
                
                document.Close();
                
                File.WriteAllBytes(@"C:\my_template.pdf", stream.ToArray());
            }
