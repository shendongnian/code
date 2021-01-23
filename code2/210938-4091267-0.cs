    public class ExcelRead
    {
        public void ReadExcel()
        {
            FileInfo existingFile = new FileInfo(@"C:\temp\book1.xlsx");
            using (ExcelPackage xlPackage = new ExcelPackage(existingFile))
            {
                foreach (ExcelWorksheet worksheet in xlPackage.Workbook.Worksheets)
                {
                    var dimension = worksheet.Dimension();
                    for (int row = dimension.StartRow; row <= dimension.EndRow; row++)
                    {
                        for (int col = dimension.StartColumn; col <= dimension.EndColumn; col++)
                        {
                            Console.WriteLine(row + ":" + col + " - " + worksheet.Cell(row, col));
                        }
                    }
                }
            }
        }
    }
    public class Dimension
    {
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int EndRow { get; set; }
        public int EndColumn { get; set; }
    }
    public static class ExcelHelper
    {
        private static readonly char[] _numbers = new[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public static Dimension Dimension(this ExcelWorksheet worksheet)
        {
            string range =
                worksheet.WorksheetXml.SelectSingleNode("//*[local-name()='dimension']").Attributes["ref"].Value;
            string[] rangeCoordinates = range.Split(':');
            int idx = rangeCoordinates[0].IndexOfAny(_numbers);
            int startRow = int.Parse(rangeCoordinates[0].Substring(idx));
            int startCol = ConvertFromExcelColumnName(rangeCoordinates[0].Substring(0, idx));
            if (rangeCoordinates.Length == 1)
                return new Dimension
                           {StartRow = startRow, StartColumn = startCol, EndRow = startRow, EndColumn = startCol};
            idx = rangeCoordinates[1].IndexOfAny(_numbers);
            int endRow = int.Parse(rangeCoordinates[1].Substring(idx));
            int endCol = ConvertFromExcelColumnName(rangeCoordinates[1].Substring(0, idx));
            return new Dimension {StartRow = startRow, StartColumn = startCol, EndRow = endRow, EndColumn = endCol};
        }
        public static int ConvertFromExcelColumnName(string name)
        {
            name = name.ToUpper();
            int result = 0;
            for (int i = 0; i < name.Length - 1; i++)
            {
                int val = name[i] - 64;
                int columnVal = (int) Math.Pow(26, name.Length - i - 1);
                result += val*columnVal;
            }
            result += name[name.Length - 1] - 64;
            return result;
        }
    }
