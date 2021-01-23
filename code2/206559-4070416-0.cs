    const string systemVar_DwgCheck = "DWGCHECK";
    Int16 dwgCheckPrevious = (Int16)Application.GetSystemVariable(systemVar_DwgCheck);
    Application.SetSystemVariable(systemVar_DwgCheck, 2);
    Document document = Application.DocumentManager.Open(@"C:\Drawings\MyDrawing.dwg", false);
    // Do stuff...
    Application.SetSystemVariable(systemVar_DwgCheck, dwgCheckPrevious);
