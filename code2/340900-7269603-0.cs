    static void ChangeConnectionStrings(string directoryName, string oldServerName, string newServerName)
    {            
        var directory = new DirectoryInfo(directoryName);
        //get all the excel files from the directory
        var files = directory.GetFiles("*.xls", SearchOption.AllDirectories);
            
        Microsoft.Office.Interop.Excel.Application application = null;
        try
        {
            //create a new application
            application = new Microsoft.Office.Interop.Excel.Application();
            //change the connection strings in each file
            foreach (var file in files)
            {
                //open the file
                application.Workbooks.Open(file.FullName);
                //get any query tables from the file
                var sheets = application.Sheets.OfType<Worksheet>();
                var queryTables = sheets.SelectMany(s => GetQueryTables(s));
                //change the connection string for any query tables
                foreach (var queryTable in queryTables)
                {
                    queryTable.Connection = queryTable.Connection.Replace(oldServerName, newServerName);
                }
                //get the pivot table data for the workbook
                var workbooks = application.Workbooks.Cast<Workbook>();
                var pivotCaches = workbooks.SelectMany(w => GetPivotCaches(w));
                //change the connection string for any pivot tables
                foreach (var pivotCache in pivotCaches)
                {
                    pivotCache.Connection = pivotCache.Connection.Replace(oldServerName, newServerName);
                }
                Console.WriteLine("Saving " + file.Name);
                //save the changes
                foreach (var workbook in workbooks)
                {
                    workbook.Save();
                    workbook.Close();
                }
            }
        }
        finally
        {
            //make sure we quit the application
            if (application != null)
                application.Quit();
        }
    }
    //PivotCaches isn't Enumerable so we can't just use Cast<PivotCache>, therefore we need a helper function
    static IEnumerable<PivotCache> GetPivotCaches(Workbook workbook)
    {
        foreach (PivotCache pivotCache in workbook.PivotCaches())
            yield return pivotCache;
    }
    //QueryTables isn't Enumerable so we can't just use Cast<QueryTable>, therefore we need a helper function
    static IEnumerable<QueryTable> GetQueryTables(Worksheet worksheet)
    {
        foreach (QueryTable queryTable in worksheet.QueryTables)
            yield return queryTable;
    }
