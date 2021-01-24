    public ExportExcel(List<OrdViewModel> ol)
    {
        using (var ew = new ExcelWriter("C:\\temp\\test.xlsx"))
        {
            for (var row = 1; row <= ol.Count; row++)
            {
                var item = ol[row-1];
                ew.Write(item.YourProperty1, 1, row);
                ew.Write(item.YourProperty2, 2, row);
                ew.Write(item.YourProperty3, 3, row);
                ew.Write(item.YourProperty4, 4, row);
            }
        }
    }
