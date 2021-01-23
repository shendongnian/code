    // Add via file to existing spreadsheet
    try
    {
        ExcelTools.AddImage(false, filePath, "Sheet name",
                            imagePath, "Image description",
                            2 /* column */, 2 /* row */);
    }
    catch ...
    // Add via stream to existing spreadsheet
    try
    {
        ExcelTools.AddImage(false, filePath, "Sheet name",
                            imageStream, "Image description",
                            2 /* column */, 2 /* row */);
    }
    catch ...
    // Create spreadsheet and add image via path
    try
    {
        ExcelTools.AddImage(true, filePath, "Sheet name",
                            imagePath, "Image description",
                            2 /* column */, 2 /* row */);
    }
    catch ...
    // Create spreadsheet and add image via stream
    try
    {
        ExcelTools.AddImage(true, filePath, "Sheet name",
                            imageStream, "Image description",
                            2 /* column */, 2 /* row */);
    }
    catch ...
    // Add multiple images or apply further changes
    try
    {
        // Open spreadsheet
        spreadsheetDocument = SpreadsheetDocument.Open(excelFile, true);
        // Get WorksheetPart
        worksheetPart = ExcelTools.GetWorksheetPartByName(spreadsheetDocument, "Some sheet name");
        AddImage(worksheetPart, imagePath1, "My first image", 1, 1); // A1
        AddImage(worksheetPart, imagePath2, "My second image", 1, 5); // A5
        AddImage(worksheetPart, imagePath3, "My third image", 2, 7); // B7
        
        // Other operations if needed
        worksheetPart.Worksheet.Save();
        spreadsheetDocument.Close();
    }
    catch ...
