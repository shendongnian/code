    public void ExportGridToExcel()
    {
        TableView.Grid.Columns["*FieldName*"].EditSettings = new TextEditSettings();
        TableView.ExportToXls(@"C:\temp\spreadsheet.xls");
        
        TableView.Grid.Columns["*FieldName*"].EditSettings = new CheckEditSettings();
    }
