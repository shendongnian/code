    public static void csvToXls(string source, string destination, string fileName)
    {
        string csvFileName = source;
        string excelFileName = destination + "/" + fileName + ".xls";
        string worksheetsName = "sheet 1";
        bool firstRowIsHeader = false;
        var format = new ExcelTextFormat();
        var edataTypes = new eDataTypes[] { eDataTypes.String, eDataTypes.String, eDataTypes.String };
        format.DataTypes = edataTypes;
        format.Delimiter = '|';
        format.EOL = "\n";              // DEFAULT IS "\r\n";
                                        // format.TextQualifier = '"';
        using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
            worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFileName), format, OfficeOpenXml.Table.TableStyles.None, firstRowIsHeader);
 
            package.Save();
        }
    }
