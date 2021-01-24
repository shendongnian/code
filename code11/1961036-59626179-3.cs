        public static readonly String DEST = "splitDocument1_{0}.pdf";
        public void Split()
        {
            IList<int> splitByPage = new List<int>() {1, 2, 3};
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(@"C:\temp\hello.pdf"));
            PdfSplitter splitter = new PdfSplitter(pdfDoc);
            IList<PdfDocument> splittedDocuments = new CustomPdfSplitter(pdfDoc, DEST).SplitByPageNumbers(splitByPage);
            foreach (PdfDocument doc in splittedDocuments)
            {
                doc.Close();
            }
            pdfDoc.Close();
        }
        private class CustomPdfSplitter : PdfSplitter
        {
            private String dest;
            private int partNumber = 1;
            public CustomPdfSplitter(PdfDocument pdfDocument, String dest) : base(pdfDocument)
            {
                this.dest = dest;
            }
            protected override PdfWriter GetNextPdfWriter(PageRange documentPageRange)
            {
                return new PdfWriter(String.Format(dest, partNumber++));
            }
        }
