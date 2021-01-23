    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    namespace TestOpenXmlSDK
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pathSource = @"D:\sample.xlsx";
                using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fsSource.Length];
                    fsSource.Read(bytes, 0, (int)fsSource.Length);
                    using (MemoryStream mem = new MemoryStream())
                    {
                        mem.Write(bytes, 0, (int)bytes.Length);
                        using (SpreadsheetDocument excelDocument = SpreadsheetDocument.Open(mem, true))
                        {
                            var wbPart = excelDocument.WorkbookPart;
                            var wsPart = wbPart.WorksheetParts.First();
                            var sheetData = wsPart.Worksheet.GetFirstChild<SheetData>();
    
                            var cellValue = GetCellValue(GetCell(sheetData, "B2"), wbPart);
                        }
                    }
                }
            }
    
            public static Cell GetCell(SheetData sheetData, string cellAddress)
            {
                uint rowIndex = uint.Parse(Regex.Match(cellAddress, @"[0-9]+").Value);
                return sheetData.Descendants<Row>().FirstOrDefault(p => p.RowIndex == rowIndex).Descendants<Cell>().FirstOrDefault(p => p.CellReference == cellAddress);
            }
    
            public static string GetCellValue(Cell cell, WorkbookPart wbPart)
            {
                string value = cell.InnerText;
                if (cell.DataType != null)
                {
                    switch (cell.DataType.Value)
                    {
                        case CellValues.SharedString:
                            var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
                            if (stringTable != null)
                            {
                                value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                            }
                            break;
    
                        case CellValues.Boolean:
                            switch (value)
                            {
                                case "0":
                                    value = "FALSE";
                                    break;
                                default:
                                    value = "TRUE";
                                    break;
                            }
                            break;
                    }
                }
                return value;
            }
        }
    }
