        private static void TestExcel()
        {
            using (var Spreadsheet = SpreadsheetDocument.Create("C:\\Example.xlsx", SpreadsheetDocumentType.Workbook))
            {
                // Create workbook.
                var WorkbookPart = Spreadsheet.AddWorkbookPart();
                var Workbook = WorkbookPart.Workbook = new Workbook();
                // Add Stylesheet.
                var WorkbookStylesPart = WorkbookPart.AddNewPart<WorkbookStylesPart>();
                WorkbookStylesPart.Stylesheet = GetStylesheet();
                WorkbookStylesPart.Stylesheet.Save();
                // Create worksheet.
                var WorksheetPart = Spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
                var Worksheet = WorksheetPart.Worksheet = new Worksheet();
                // Add data to worksheet.
                var SheetData = Worksheet.AppendChild(new SheetData());
                SheetData.AppendChild(new Row(
                    //Date example. Will show as dd/MM/yyyy. 
                    new Cell() { CellValue = new CellValue(DateTime.Today.ToOADate().ToString(CultureInfo.InvariantCulture)), StyleIndex = 1 },
                    //Date Time example. Will show as dd/MM/yyyy HH:mm
                    new Cell() { CellValue = new CellValue(DateTime.Now.ToOADate().ToString(CultureInfo.InvariantCulture)), StyleIndex = 2 },
                    //Number example
                    new Cell() { CellValue = new CellValue(123.23d.ToString(CultureInfo.InvariantCulture)), StyleIndex = 0 },
                    //String example
                    new Cell() { CellValue = new CellValue("Test string"), DataType = CellValues.String }
                ));
                // Link worksheet to workbook.
                var Sheets = Workbook.AppendChild(new Sheets());
                Sheets.AppendChild(new Sheet()
                {
                    Id = WorkbookPart.GetIdOfPart(WorksheetPart),
                    SheetId = (uint)(Sheets.Count() + 1),
                    Name = "Example"
                });
                Workbook.Save();
            }
        }
        private static Stylesheet GetStylesheet()
        {
            var StyleSheet = new Stylesheet();
            // Create "fonts" node.
            var Fonts = new Fonts();
            Fonts.Append(new Font()
            {
                FontName = new FontName() { Val = "Calibri" },
                FontSize = new FontSize() { Val = 11 },
                FontFamilyNumbering = new FontFamilyNumbering() { Val = 2 },
            });
            Fonts.Count = (uint)Fonts.ChildElements.Count;
            // Create "fills" node.
            var Fills = new Fills();
            Fills.Append(new Fill()
            {
                PatternFill = new PatternFill() { PatternType = PatternValues.None }
            });
            Fills.Append(new Fill()
            {
                PatternFill = new PatternFill() { PatternType = PatternValues.Gray125 }
            });
            Fills.Count = (uint)Fills.ChildElements.Count;
            // Create "borders" node.
            var Borders = new Borders();
            Borders.Append(new Border()
            {
                LeftBorder = new LeftBorder(),
                RightBorder = new RightBorder(),
                TopBorder = new TopBorder(),
                BottomBorder = new BottomBorder(),
                DiagonalBorder = new DiagonalBorder()
            });
            Borders.Count = (uint)Borders.ChildElements.Count;
            // Create "cellStyleXfs" node.
            var CellStyleFormats = new CellStyleFormats();
            CellStyleFormats.Append(new CellFormat()
            {
                NumberFormatId = 0,
                FontId = 0,
                FillId = 0,
                BorderId = 0
            });
            CellStyleFormats.Count = (uint)CellStyleFormats.ChildElements.Count;
            // Create "cellXfs" node.
            var CellFormats = new CellFormats();
            // StyleIndex = 0, A default style that works for most things (But not strings? )
            CellFormats.Append(new CellFormat()
            {
                BorderId = 0,
                FillId = 0,
                FontId = 0,
                NumberFormatId = 0,
                FormatId = 0,
                ApplyNumberFormat = true
            });
            // StyleIndex = 1, A style that works for DateTime (just the date)
            CellFormats.Append(new CellFormat()
            {
                BorderId = 0,
                FillId = 0,
                FontId = 0,
                NumberFormatId = 14, //Date
                FormatId = 0,
                ApplyNumberFormat = true
            });
            // StyleIndex = 2, A style that works for DateTime (Date and Time)
            CellFormats.Append(new CellFormat()
            {
                BorderId = 0,
                FillId = 0,
                FontId = 0,
                NumberFormatId = 22, //Date Time
                FormatId = 0,
                ApplyNumberFormat = true
            });
            CellFormats.Count = (uint)CellFormats.ChildElements.Count;
            // Create "cellStyles" node.
            var CellStyles = new CellStyles();
            CellStyles.Append(new CellStyle()
            {
                Name = "Normal",
                FormatId = 0,
                BuiltinId = 0
            });
            CellStyles.Count = (uint)CellStyles.ChildElements.Count;
            // Append all nodes in order.
            StyleSheet.Append(Fonts);
            StyleSheet.Append(Fills);
            StyleSheet.Append(Borders);
            StyleSheet.Append(CellStyleFormats);
            StyleSheet.Append(CellFormats);
            StyleSheet.Append(CellStyles);
            return StyleSheet;
        }
