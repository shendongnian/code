        using (var spreadsheet = SpreadsheetDocument.Open(filepath, true))
        {
                PivotTableCacheDefinitionPart ptp = spreadsheet.WorkbookPart.PivotTableCacheDefinitionParts.First();
                ptp.PivotCacheDefinition.RefreshOnLoad = true;//refresh the pivot table on document load
                ptp.PivotCacheDefinition.RecordCount = Convert.ToUInt32(ds.Tables[0].Rows.Count);
                ptp.PivotCacheDefinition.CacheSource.WorksheetSource.Reference = "A1:" + IntToLetters(ds.Tables[0].Columns.Count) + (ds.Tables[0].Rows.Count + 1);//Cell Range as data source
                ptp.PivotTableCacheRecordsPart.PivotCacheRecords.RemoveAllChildren();//it is rebuilt when pivot table is refreshed
                ptp.PivotTableCacheRecordsPart.PivotCacheRecords.Count = 0;//it is rebuilt when pivot table is refreshed
        }
        public string IntToLetters(int value)//copied from another stackoverflow post
        {
                string result = string.Empty;
                while (--value >= 0)
                {
                    result = (char)('A' + value % 26) + result;
                    value /= 26;
                }
                return result;
        }
