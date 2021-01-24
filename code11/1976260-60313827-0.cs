        private void WriteException(DataTable dt)
        {           
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Exceptions");
                var worksheet = excel.Workbook.Worksheets["Exceptions"];
                worksheet.Cells["A1"].LoadFromDataTable(dt,false);
                FileInfo excelFile = new FileInfo(@"C:\Temp\AllExceptions.xlsx");
                excel.SaveAs(excelFile);
            }
        }
