    var currentFile = new ExcelFile();
    var currentSheet = currentFile.AppendSheet(rows[0].SheetName);
    string lastFileName;
    
    for(int i = 0; i < rows.Count; i++)
    {
        // Adds new file if necessary
        if(i != 0 && rows[i].ModalityId != rows[i - 1].ModalityId)
        {
            currentFile.Save(rows[i - 1].FileName);
            currentFile = new ExcelFile();
        }
        // Adds new sheet if necessary
        if(i != 0 && rows[i].ID != rows[i - 1].ID)
        {
            currentSheet = currentFile.AppendSheet(rows[i].SheetName);
        }
    
        InsertData(currentSheet, rows[i]);
        lastFileName = rows[i].FileName;
    }
    
    currentFile.Save(lastFileName);
