            string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Landscape.pdf");
            
            using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (Document doc = new Document(PageSize.LETTER.Rotate()))
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                    {
                        writer.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);
                        doc.Open();
                        doc.Add(new Paragraph("test"));
                        doc.Close();
                    }
                }
            }
