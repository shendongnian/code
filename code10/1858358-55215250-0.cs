    class Program
        {
            static void Main(string[] args)
            {
                var dic1 = new Dictionary<string, string>
            {
                {"H2","FPT1" },
                {"AA2","IPN1" },
            };
    
                var dic2 = new Dictionary<string, string>
            {
                {"H3","FPT2" },
                {"AA3","IPN2" },
            };
                var dic3 = new Dictionary<string, string>
            {
                {"H4","FPT3" },
                {"AA4","IPN3" },
            };
                var dic4 = new Dictionary<string, string>
            {
                {"H5","FPT4" },
                {"AA5","IPN4" },
            };
                var data = new List<Dictionary<string, string>>
                {
                    dic1,
                    dic2,
                    dic3,
                    dic4
                };
    
                CreateSpreadsheetWorkbook(@"C:\Priyank\Desktop\Myfile.xlsx", data);
            }
    
            public static void CreateSpreadsheetWorkbook(string filepath, List<Dictionary<string, string>> Data)
            {
                // Create a spreadsheet document by supplying the filepath.
                // By default, AutoSave = true, Editable = true, and Type = xlsx.
                var spreadsheetDocument = SpreadsheetDocument.Create(filepath, SpreadsheetDocumentType.Workbook);
    
                // Add a WorkbookPart to the document.
                var workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();
    
                // Add Sheets to the Workbook.
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
    
                // Add a WorksheetPart to the WorkbookPart.
                var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                // Get the sheetData cell table.
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet();
    
                var rowindex = 2;
                foreach (var _row in Data)
                {
                    var row = new Row
                    {
                        RowIndex = (uint)rowindex
                    };
                    foreach (var pair in _row)
                    {
                        var newCell = new Cell { CellReference = pair.Key, DataType = CellValues.InlineString };
                        var inlineString = new InlineString();
                        var t = new Text
                        {
                            Text = pair.Value
                        };
                        inlineString.AppendChild(t);
                        newCell.AppendChild(inlineString);
                        row.AppendChild(newCell);
                    }
                    sheetData.AppendChild(row);
                    rowindex++;
                }
    
                worksheetPart.Worksheet.Append(sheetData);
    
                // Append a new worksheet and associate it with the workbook.
                var sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "mySheet" };
                sheets.Append(sheet);
    
                spreadsheetDocument.Save();
                // Close the document.
                spreadsheetDocument.Close();
            }
        }
