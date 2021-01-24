            SLDocument sl = new SLDocument();
            List<string> columnName = new List<string>();
            int rowNumber = 1;
            int currentColumnNumber = 1;
            //set headers
            foreach (DataColumn dataColumn in dvRecords.Table.Columns)
            {
                columnName.Add(dataColumn.ColumnName);
                sl.SetCellValue(rowNumber, currentColumnNumber, dataColumn.ColumnName.Replace("_", " "));
                currentColumnNumber++;
            }
            rowNumber++;
            currentColumnNumber = 1;
            foreach (DataRow dataRow in dvRecords.Table.Rows)
            {
                foreach (var column in columnName)
                {
                    sl.SetCellValue(rowNumber, currentColumnNumber, dataRow[column].ToString());
                    currentColumnNumber++;
                }
                rowNumber++;
                currentColumnNumber = 1;
            }
            sl.SaveAs(filename);
