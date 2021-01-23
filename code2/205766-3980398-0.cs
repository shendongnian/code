        public static byte[] concatAndAddContent(List<byte[]> pdf)
        {
            byte [] todos;
            using(MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                doc.SetPageSize(PageSize.LETTER);
                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;
                //PdfCopy copy = new PdfCopy(doc, ms);
                //PdfCopy.PageStamp stamp;
                PdfReader reader;
                foreach (byte[] p in pdf)
                {
                    reader = new PdfReader(p);
                    int pages = reader.NumberOfPages;
                    // loop over document pages
                    for (int i = 1; i <= pages; i++)
                    {
                        doc.SetPageSize(PageSize.LETTER);
                        doc.NewPage();
                        page = writer.GetImportedPage(reader, i);
                        cb.AddTemplate(page, 0, 0);
                        //page = copy.GetImportedPage(reader, i);
                        //stamp = copy.CreatePageStamp(page);
                        //cb = stamp.GetUnderContent();
                        //cb.SaveState();
                        //stamp.AlterContents();
                        //copy.AddPage(page);
                    }
                }
                doc.Close();
                todos = ms.GetBuffer();
                ms.Flush();
                ms.Dispose();
            }
            return todos;
        }
