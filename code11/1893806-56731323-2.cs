    static void Main(string[] args)
    {
        string outputPath = "‪output.xls";
        List<string> files = new List<string>();
        files.Add(@"File1.xls");
        files.Add(@"File2.xls");
        CombineFiles(files, outputPath);
    }
    private static void CombineFiles(List<string> files, string outputPath)
    {
        Spire.Xls.Workbook resultworkbook = new Spire.Xls.Workbook();
        resultworkbook.Worksheets.Clear();
        Spire.Xls.Worksheet resultworksheet = resultworkbook.Worksheets.Add("worksheet");
        Spire.Xls.Workbook workbook = new Spire.Xls.Workbook();
        for (int i = 0; i < files.Count; i++)
        {
            workbook.LoadFromFile(files[i]);
            Worksheet sheet = workbook.Worksheets[0];
            if (i == 0)
            {
                sheet.AllocatedRange.Copy(resultworksheet.Range[1, 1], true, true);
            }
            else
            {
                sheet.AllocatedRange.Copy(resultworksheet.Range[resultworksheet.LastRow + 1, 1], true, true);
            }
        }
        resultworkbook.SaveToFile(outputPath, ExcelVersion.Version97to2003);
    }
