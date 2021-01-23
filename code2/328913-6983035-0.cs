            //Output file
            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Table.pdf");
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (Document doc = new Document(PageSize.LETTER))
                {
                    using (PdfWriter w = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.Open();
                        doc.NewPage();
                        //Create some long text to force a new page
                        string longText = String.Concat(Enumerable.Repeat("Lorem ipsum.", 40));
                        //Create our table using both THEAD and TH which iTextSharp currently ignores
                        string html = "<table>";
                        html += "<thead><tr><th>Header Row 1/Cell 1</th><th>Header Row 1/Cell 2</th></tr><tr><th>Header Row 2/Cell 1</th><th>Header Row 2/Cell 2</th></tr></thead>";
                        html += "<tbody>";
                        for (int i = 3; i < 20; i++)
                        {
                            html += "<tr>";
                            html += String.Format("<td>Data Row {0}</td>", i);
                            html += String.Format("<td>{0}</td>", longText);
                            html += "</tr>";
                        }
                        html += "</tbody>";
                        html += "</table>";
                        using (StringReader sr = new StringReader(html))
                        {
                            //Get our list of elements (only 1 in this case)
                            List<IElement> elements = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(sr, null);
                            foreach (IElement el in elements)
                            {
                                //If the element is a table manually set its header row count
                                if (el is PdfPTable)
                                {
                                    ((PdfPTable)el).HeaderRows = 2;
                                }
                                doc.Add(el);
                            }
                        }
                        doc.Close();
                    }
                }
            }
