            PdfReader pdfReader = new PdfReader(model.Input);
            Document document = new Document(pdfReader.GetPageSizeWithRotation(1));
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, ms);
                document.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page = writer.GetImportedPage(pdfReader, 1);
                cb.AddTemplate(page, 0, 0);
                int countOfPages = (int)Math.Ceiling(Convert.ToDecimal(model.ActiveDriverList.Count - countDriversOnFirstPage) / countDriversOnEmptyPage);
                for (int i = 0; i < countOfPages; i++)
                {
                    PdfReader readerPage = new PdfReader(model.EmptyPage);
                    readerPage.ConsolidateNamedDestinations();
                    document.SetPageSize(pdfReader.GetPageSizeWithRotation(1));
                    document.NewPage();
                    PdfImportedPage importedPage = writer.GetImportedPage(readerPage, 1);
                    cb = AddTextDriversNextPage(cb, model.ActiveDriverList, i + 1);
                    cb.AddTemplate(importedPage, 0, 0);
                }
                document.Close();
                writer.Close();
                return ms.ToArray();
            }
