    public String GetText(Stream s, int pageNum, int charIndex, int count)
    {
       using (PdfTextDocument doc = new PdfTextDocument(s))
       {
           PdfTextPage textPage = doc.GetPage(pageNum);                    
           return textPage.GetText(charIndex, count);
       }
    }
