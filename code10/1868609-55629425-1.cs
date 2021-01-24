    static void Main(string[] args)
    {
            string[] filePaths = Directory.GetFiles("{Directory_Path}", "*.pdf", SearchOption.AllDirectories);
            int noOfPages = 0;
            string filePath = "";
            for(int i= 0;i < filePaths.Length;i++)
            {
                int tmp = GetNumberOfPdfPages(filePaths[i]);
                if(i==0)
                {
                    noOfPages = tmp;
                    filePath = filePaths[i];
                }
                else
                {
                    if(tmp > noOfPages)
                    {
                        noOfPages = tmp;
                        filePath = filePaths[i];
                    }
                }
            }
    }
    public static int GetNumberOfPdfPages(string fileName)
    {
            PdfReader pdfReader = new PdfReader(fileName); // use iTextSharp for PdfReader class.
            int numberOfPages = pdfReader.NumberOfPages;
            return numberOfPages;
    }
