            using (PdfDocument one = PdfReader.Open("pdf 1.pdf", PdfDocumentOpenMode.Import))
            using (PdfDocument two = PdfReader.Open("pdf 2.pdf", PdfDocumentOpenMode.Import))
            using (PdfDocument outPdf = new PdfDocument())
            {
                CopyPages(one, outPdf);
                CopyPages(two, outPdf);
                outPdf.Save("file1and2.pdf");
            }
            void CopyPages(PdfDocument from, PdfDocument to)
            {
                for (int i = 0; i < from.PageCount; i++)
                {
                    to.AddPage(from.Pages[i]);
                }
            }
