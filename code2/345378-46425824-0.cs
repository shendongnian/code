     public void pdfproperties()
        {
            string inputFile = @"D:\1.pdf";
            string outputFile = @"D:\48.pdf";
            PdfReader reader = new PdfReader(inputFile);
            foreach (KeyValuePair<string, string> KV in reader.Info)
            {
                reader.Info.Remove(KV.Key);
            }
            using (FileStream FS = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (Document Doc = new Document())
                {
                    using (PdfCopy writer = new PdfCopy(Doc, FS))
                    {
                        Doc.Open();
                        Doc.AddTitle("Add Title");
                        Doc.AddSubject("Add Subject");
                        Doc.AddKeywords("Add Keywords");
                        Doc.AddCreator("Application Creator");
                        Doc.AddAuthor("Add Author");
                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            writer.AddPage(writer.GetImportedPage(reader, i));
                        }
                        writer.Info.Put(new PdfName("Producer"), new PdfString("Producer Name"));
                        Doc.Close();
                    }
                }
            }
        }
