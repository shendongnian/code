            ClosedXML.Excel.IXLWorkbook workbook = new XLWorkbook(@"D:\Test.xlsx");
            var worksheet = workbook.Worksheets.First();
            int column = 1;
            int row = 1;
            int stringNum = 0;
            List<string> result = new List<string>();
            try
            {
                while (worksheet.Cell(row, column).Value != null && row < worksheet.RowCount())
                {
                    result.Add(worksheet.Cell(row, column).Value.ToString());
                    row++;
                    stringNum++;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Error: " + e.ToString());
            }
