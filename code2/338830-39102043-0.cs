            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Open(SourceXlsxName, false))
                {
                    foreach (Sheet _Sheet in document.WorkbookPart.Workbook.Descendants<Sheet>())
                    {
                        WorksheetPart _WorksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(_Sheet.Id);
                        Worksheet _Worksheet = _WorksheetPart.Worksheet;
                        SharedStringTablePart _SharedStringTablePart = document.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                        SharedStringItem[] _SharedStringItem = _SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ToArray();
                        if (string.IsNullOrEmpty(DestinationCsvDirectory))
                            DestinationCsvDirectory = Path.GetDirectoryName(SourceXlsxName);
                        string newFilename = string.Format("{0}_{1}.csv", Path.GetFileNameWithoutExtension(SourceXlsxName), _Sheet.Name);
                        newFilename = Path.Combine(DestinationCsvDirectory, newFilename);
                        using (var outputFile = File.CreateText(newFilename))
                        {
                            foreach (var row in _Worksheet.Descendants<Row>())
                            {
                                StringBuilder _StringBuilder = new StringBuilder();
                                foreach (Cell _Cell in row)
                                {
                                    string Value = string.Empty;
                                    if (_Cell.CellValue != null)
                                    {
                                        if (_Cell.DataType != null && _Cell.DataType.Value == CellValues.SharedString)
                                            Value = _SharedStringItem[int.Parse(_Cell.CellValue.Text)].InnerText;
                                        else
                                            Value = _Cell.CellValue.Text;
                                    }
                                    _StringBuilder.Append(string.Format("{0},", Value.Trim()));
                                }
                                outputFile.WriteLine(_StringBuilder.ToString().TrimEnd(','));
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
