    public static void OpenTestFile()
    {
        using (var wb = new XLWorkbook("test.xlsx"))
        {
            foreach (var ws in wb.Worksheets)
            {
                foreach (var mr in ws.MergedRanges)
                {
                    var firstCellInMergedRange = mr.FirstCell();
                }
            }
        }
    }
