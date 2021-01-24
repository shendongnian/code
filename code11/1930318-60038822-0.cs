            using UglyToad.PdfPig;
            [...]
            using (PdfDocument document = PdfDocument.Open(pathToFile))
            {
                for (int p = 0; p < document.NumberOfPages; p++)
                {
                    var page = document.GetPage(p + 1);
                    // extract the page's marked content
                    var markedContents = page.GetMarkedContents(); 
                    var orderedMarkedContents = markedContents
                           .OrderBy(mc => mc.MarkedContentIdentifier);
                    foreach (var mc in orderedMarkedContents)
                    {
                        // do something
                    }
                }
            }
