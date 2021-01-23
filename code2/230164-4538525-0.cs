            using (FileStream fs = File.Create("test.pdf"))
            {
                Document document = new Document(PageSize.A4, 72, 72, 72, 72);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                int pageNumber = -1;
                for (int i = 0; i < 20; i++)
                {
                    if (pageNumber != writer.PageNumber)
                    {
                        // Add image
                        pageNumber = writer.PageNumber;
                    }
                    // Add something else
                }
                document.Close();
            }
