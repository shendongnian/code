    public void RunArchiveInternal2(bool testRun)
    {
        //internal
        string SheetIDInternal = "googlesheetid_internal";
        string RangeInternal = testRun ? "test_task tracking" : "Task Tracking - INTERNAL";
        SpreadsheetsResource.ValuesResource.GetRequest getRequestInternal = sheetsService.Spreadsheets.Values.Get(SheetIDInternal, RangeInternal);
        ValueRange ValuesInternal = getRequestInternal.Execute();
        //internal archive
        string SheetIDInternalArchive = "googlesheetid_internal_archive";
        string RangeInternalArchive = testRun ? "test_archive_internal" : "Sheet1";
        SpreadsheetsResource.ValuesResource.GetRequest getRequestInternalArchive = sheetsService.Spreadsheets.Values.Get(SheetIDInternalArchive, RangeInternalArchive);
        ValueRange ValuesInternalArchive = getRequestInternalArchive.Execute();
        
        //Get data from internal and put to internal archive
        List<IList<object>> listOfValuesToInsert = new List<IList<object>>();            
        for (int i = 1; i <= ValuesInternal.Values.Count() - 1; i++)
        {
            List<object> rowToUpdate = new List<object>();
            if (ValuesInternal.Values[i][1] != null && ValuesInternal.Values[i][1].ToString().ToUpper() == "TASK COMPLETE")
            {
                rowToUpdate = (List<object>)ValuesInternal.Values[i];
                listOfValuesToInsert.Add(rowToUpdate);
            }
        } 
        SpreadsheetsResource.ValuesResource.AppendRequest insertRequest = sheetsService.Spreadsheets.Values.Append(new ValueRange { Values = listOfValuesToInsert }, SheetIDInternalArchive, RangeInternalArchive + "!A1");
        insertRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
        insertRequest.Execute();
        //delete things from internal
        BatchUpdateSpreadsheetRequest batchUpdateSpreadsheetRequest = new BatchUpdateSpreadsheetRequest();
        List<DeleteDimensionRequest> requests = new List<DeleteDimensionRequest>();
        for (int i = ValuesInternal.Values.Count() - 1; i >= 1; i--)
        {
            DeleteDimensionRequest request = new DeleteDimensionRequest();
            //Request request = new Request();
            if (ValuesInternal.Values[i][1] != null && ValuesInternal.Values[i][1].ToString().ToUpper() == "TASK COMPLETE")
            {
                request.Range = new DimensionRange
                {
                    Dimension = "ROWS",
                    StartIndex = i,
                    EndIndex = i
                };
                requests.Add(request);
            }
        }
        batchUpdateSpreadsheetRequest.Requests = requests;//this is wrong
        SpreadsheetsResource.BatchUpdateRequest Deletion = sheetsService.Spreadsheets.BatchUpdate(batchUpdateSpreadsheetRequest, SheetIDInternal);
        Deletion.Execute();
    }
