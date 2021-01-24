    using (var wb = new XLWorkbook("test.xlsx"))
    {
        var nr = wb.NamedRange("MyRange");
        foreach (var range in nr.Ranges)
        {
            var cellsToFind = range.Cells(c => c.MergedRange().FirstCell() == c);
            Console.WriteLine($"{cellsToFind.First().Address}:{cellsToFind.Last().Address}");
        }
    }
