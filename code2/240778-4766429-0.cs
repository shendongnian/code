    private const string FORMAT_EXCEL_CONNECT =
            // @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR={1}""";
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0;HDR={1}""";
        private static string GetExcelConnectionString(string excelFilePath, bool header)
        {
            return string.Format(FORMAT_EXCEL_CONNECT,
                excelFilePath,
                (header) ? "Yes" : "No"
                );
        }
