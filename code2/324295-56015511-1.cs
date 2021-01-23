        public void ExportToExcel()
        {
            // Initialize app and pop Excel on the screen.
            var excelApp = new Excel.Application
            {
                Visible = true
            };
            // I use unix time to give the files a unique name that's almost somewhat useful.
            DateTime dateTime = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
            var path = @"C:\Users\my\path\here + unixTime + ".csv";
            var csv = GetCSV();
            File.WriteAllText(path, csv);
            // Create a new workbook and get its active sheet.
            excelApp.Workbooks.Open(path);
            var workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
            
            // iterrate through each value and throw it in the chart
            for (var column = 0; column < Data.Count; column++)
            {
                ((Excel.Range)workSheet.Columns[column + 1]).AutoFit();
            }
            currentSheet = workSheet;
        }
