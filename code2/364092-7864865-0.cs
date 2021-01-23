     pdfDoc = (Acrobat.CAcroPDDoc)
     Microsoft.VisualBasic.Interaction.CreateObject("Ac roExch.PDDoc", "");
     int ret = pdfDoc.Open(inputFile);
     if (ret == 0)
     {
         throw new FileNotFoundException();
     }
    // Get the number of pages (to be used later if you wanted to store that information)
     int pageCount = pdfDoc.GetNumPages();
    // Get the first page
    pdfPage = (Acrobat.CAcroPDPage)pdfDoc.AcquirePage(0);
    pdfPoint = (Acrobat.CAcroPoint)pdfPage.GetSize();
    pdfRect = (Acrobat.CAcroRect)
    Microsoft.VisualBasic.Interaction.CreateObject("Ac roExch.Rect", "");
    pdfRect.Left = 0;
    pdfRect.right = pdfPoint.x;
    pdfRect.Top = 0;
    pdfRect.bottom = pdfPoint.y;
    // Render to clipboard, scaled by 100 percent (ie. original size)
     // Even though we want a smaller image, better for us to scale in .NET
    // than Acrobat as it would greek out small text
     pdfPage.CopyToClipboard(pdfRect, 0, 0, 100);
    IDataObject clipboardData = Clipboard.GetDataObject();
    if (clipboardData.GetDataPresent(DataFormats.Bitmap))
    {
      Bitmap pdfBitmap =
      (Bitmap)clipboardData.GetData(DataFormats.Bitmap);
    }
