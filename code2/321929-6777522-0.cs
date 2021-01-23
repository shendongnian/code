    public void DisposeExcelInstance()
    {
        app.DisplayAlerts = false;
        workBook.Close(null, null, null);
        app.Workbooks.Close();
        app.Quit();
        if (workSheet != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
        if (workBook != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
        if (app != null)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        workSheet = null;
        workBook = null;
        app = null;
        GC.Collect(); // force final cleanup!
    }
