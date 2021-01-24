            public Dictionary<string, string> ExceltoCsv(IWorkbook input)
        {
            var csvTrennzeichen = OutputSettings.ColumnSeparator.ToString();
            var result = new Dictionary<string, string>();
            for (var sheetIndex = 0; sheetIndex < input.NumberOfSheets; sheetIndex++)
            {
                var sheet = input.GetSheetAt(sheetIndex);
                var sheetresult = new List<string>();
                for (var row = sheet.FirstRowNum; row < sheet.LastRowNum; row++)
                {
                    var rowObj = sheet.GetRow(row);
                    if (rowObj.Cells.All(x => string.IsNullOrEmpty(WertAuslesen(x))))
                        continue;
                    var line = string.Join(csvTrennzeichen, rowObj.Cells
                                                            .Select(cell => WertAuslesen(cell).Replace("\r", " ").Replace("\n", " "))
                                                            .Select(cell => OutputSettings.Writeinquotes ? string.Format("\"{0}\"", cell.Replace("\"", "\"\"")) : cell));
                    sheetresult.Add(line);
                }
                result.Add(sheet.SheetName, string.Join("\r\n", sheetresult));
            }
            return result;
        }
        private string WertAuslesen(ICell oldCell)
        {
            switch (oldCell.CellType)
            {
                case CellType.Boolean:
                    return oldCell.BooleanCellValue.ToString();
                case CellType.Error:
                    return oldCell.ErrorCellValue.ToString();
                case CellType.Formula:
                    return oldCell.CellFormula;
                case CellType.Numeric:
                    return !DateUtil.IsCellDateFormatted(oldCell)
                        ? oldCell.NumericCellValue.ToString(OutputSettings.GetDecimalFormat(Digits(oldCell.CellStyle.GetDataFormatString())))
                        : oldCell.DateCellValue.ToString(OutputSettings.DateFormat);
                case CellType.String:
                    return oldCell.RichStringCellValue.ToString();
                case CellType.Unknown:
                    return oldCell.StringCellValue;
                default:
                    return "";
            }
        }
        private static int Digits(string format)
        {
            var digits = format.ContainsAny(',', '.') ? format.Split(new[] { ',', '.' }).Last() : "";
            return digits.Length;
        }
