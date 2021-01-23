                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            // Reading from a binary Excel file ('97-2003 format; *.xls)
            //            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            // Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();
            // Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();
            var cdm = new ValueSetRepository();
            for (int i = 0; i < result.Tables.Count; i++)
            {
                // CHECK if tableNames filtering is specified
                if (tableNames != null)
                {
                    // CHECK if a table matches the specified tablenames
                    var tablename = result.Tables[i].TableName;
                    if (!tableNames.Contains(tablename))
                    {
                        continue;
                    }
                }
                
                var lookup = new ValueSetLookup();
                lookup.CmsId = result.Tables[i].Rows[2][0].ToString();
                lookup.NqfNumber = result.Tables[i].Rows[2][1].ToString();
                lookup.Data = new List<ValueSetAttribute>();
                int row_no = 2;
                while (row_no < result.Tables[i].Rows.Count) // i is the index of table
                // (sheet name) which you want to convert to csv
                {
                    var currRow = result.Tables[i].Rows[row_no];
                    var valueSetAttribute = new ValueSetAttribute()
                    {
                        Id = currRow[0].ToString(),
                        Number = currRow[1].ToString(),
                        tName = currRow[2].ToString(),
                        Code = currRow[7].ToString(),
                        Description = currRow[8].ToString(),
                    };
                    lookup.Data.Add(valueSetAttribute);
                    row_no++;
                }
                cdm.AddRecord(lookup);
