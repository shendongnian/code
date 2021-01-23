     var link = document.WorkbookPart.SharedStringTablePart;
               Func<Cell, string> selector = (cell) => cell.InnerText;
              if (link != null)
               {
                   SharedStringTable sharedStringTable = document.WorkbookPart.SharedStringTablePart.SharedStringTable;
                   selector = (cell) => cell.DataType == null ? cell.InnerText : cell.DataType == CellValues.SharedString ? sharedStringTable.ElementAt(Int32.Parse(cell.InnerText)).InnerText : cell.InnerText;
              }
               
             var values = wsPart.Worksheet.Descendants<Cell>().Select(cell =>selector(cell) ).ToArray();
