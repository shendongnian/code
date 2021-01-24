    static void Main(string[] args)
        {
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"D:\1.xlsx");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Data Source";
            Worksheet sheet2 = workbook.CreateEmptySheet();
            sheet2.Name = "Pivot Table";
            CellRange dataRange = sheet.Range["A1:D8"];
            PivotCache cache = workbook.PivotCaches.Add(dataRange);
            PivotTable pt = sheet2.PivotTables.Add("Pivot Table", sheet.Range["A1"], cache);
            var r1 = pt.PivotFields["ID"];
            r1.Axis = AxisTypes.Row;
            pt.Options.RowHeaderCaption = "ID";
    
            var r2 = pt.PivotFields["Description"];
            r2.Axis = AxisTypes.Row;
    
            pt.DataFields.Add(pt.PivotFields["OnHand"], "SUM of OnHand", SubtotalTypes.Sum);
            pt.DataFields.Add(pt.PivotFields["OnOrder"], "SUM of OnOrder", SubtotalTypes.Sum);
    
            pt.BuiltInStyle = PivotBuiltInStyles.PivotStyleMedium12;
            workbook.SaveToFile("D:\\PivotTable.xlsx", ExcelVersion.Version2010);
            System.Diagnostics.Process.Start("D:\\PivotTable.xlsx");
        }
