          using (SpreadsheetDocument spreadsheetDocument =   SpreadsheetDocument.Open("myFile.xlsx", false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                foreach (Row r in sheetData.Elements<Row>())
                {
                    foreach (Cell c in r.Elements<Cell>())
                    {
                        Console.Write(c.InnerText + ",");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine();
                Console.ReadKey();
            }
