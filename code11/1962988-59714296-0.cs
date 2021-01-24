    private void Generate(Document targetDocument, Dictionary<FinancialDocument, PdfDocument> files)
    {
           foreach(var file in files)
           {
                 if(accountList.Contains(file.Key.AccountNumber))
                 {
                         // your logic here
                         var pdfDocument = file.Value;
                 }
           }
    }
