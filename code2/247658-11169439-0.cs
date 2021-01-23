                foreach (var htmlElement in parsedHtmlElements)
                {
                    fixRunDirection(htmlElement);
                    pdfCell.AddElement(htmlElement);
                }
     
    ...
     
            private static void fixRunDirection(IElement htmlElement)
            {
                if (!(htmlElement is PdfPTable)) return;
     
                var table = (PdfPTable)htmlElement;
                table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
     
                foreach (var row in table.Rows)
                {
                    foreach (var cell in row.GetCells())
                    {
                        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                        foreach (var element in cell.CompositeElements)
                        {
                            fixRunDirection(element);
                        }
                    }
                }
            }
