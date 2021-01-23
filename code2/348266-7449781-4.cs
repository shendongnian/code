    sheetToCopy.Range["A1", "AC60"].Copy();
    newBook.Activate();
    newBook.Sheets.Add(Type.Missing,defaultWorksheet);
    newBook.ActiveSheet.Range["A1", "Z50"].Select();
    newBook.ActiveSheet.PasteSpecial(XlPasteType.xlPasteAllUsingSourceTheme);
