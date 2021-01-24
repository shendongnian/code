var document = new PdfDocument();
var page = document.AddPage();
var gfx = XGraphics.FromPdfPage(page);
page.Width = XUnit.FromMillimeter(111);
page.Height = XUnit.FromMillimeter(222);
//some logic to create multiple pages
document.Save("OriginalDoc.pdf");
//Logic here to open and merge the document multiple times
PdfDocument outputDocument = new PdfDocument();
 
// Open the document to import pages from it.
PdfDocument inputDocument = PdfReader.Open("C:\mydoc\OriginalDoc.pdf", PdfDocumentOpenMode.Import);
  for(int i = 0; i < Copies; i++)
  {
    // Iterate pages
    int count = inputDocument.PageCount;
    for (int idx = 0; idx < count; idx++)
    {
      // Get the page from the external document...
      PdfPage page = inputDocument.Pages[idx];
      // ...and add it to the output document.
      outputDocument.AddPage(page);
    }
  }
  // Save the document...
  const string filename = "MergedDoc.pdf";
  outputDocument.Save(filename);
I suspect this could be done without saving and re-opening the document as well, but I haven't used pdfsharp myself.
