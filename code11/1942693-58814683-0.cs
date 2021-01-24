    var currentFile = new ExcelFile();
    var currentSheet = currentFile.AppendSheet(rows[0].FileName);
    
    for(int i = 0; i < rows.Count; i++)
    {
        // Adds new file if necessary
        if(i != 0 && rows[i].ModalityId != rows[i - 1].ModalityId)
        {
            currentFile.Close();
            currentFile = new ExcelFile();
        }
        // Adds new sheet if necessary
        if(i != 0 && rows[i].ID != rows[i - 1].ID)
        {
            currentSheet = currentFile.AppendSheet(rows[i].FileName);
        }
    
        InsertData(currentSheet, rows[i]);
    }
    
    currentFile.Close();
