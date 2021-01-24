    public static void OpenTestFile()
    {
        using (var wb = new XLWorkbook("test.xlsx"))
        {
            foreach (IXLNamedRange r in wb.NamedRanges)
            {
                foreach (var c in r.Ranges.Cells())
                {
                    if (!c.IsMerged())
                        continue;
                    var firstCellInMergedRange = c.MergedRange().Cells().First();
                }
            }
        }
    }
