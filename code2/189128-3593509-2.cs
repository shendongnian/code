    private void TestRelease()
    {
        Excel.Workbook workbook = excel.ActiveWorkbook;
        using (var c = new ComObjectCleanUp(workbook))
        {
            // do stuff
        }
    }
