    public static Sheet GetSheetFromName(WorkbookPart workbookPart, string sheetName)
    {
        return workbookPart.Workbook.Sheets.Elements<Sheet>()
            .FirstOrDefault(s => s.Name.HasValue && s.Name.Value == sheetName);
    }
