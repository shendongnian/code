         public static class DataExporter
        {
    
            static DataTable dtExcel = new DataTable();
            private static void ReadData(string query)
            {
                //Get Datatable here by query or you can use LINQtoDataTable
                dtExcel = DBQuery.GetDataTableByQuery(query);
            }
    
            private static Byte[] PrepareByte(DataTable dt)
            {
                Byte[] bytes;
    
                int colCount = dt.Columns.Count;
    
                ExcelPackage excel = new ExcelPackage();
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.DefaultRowHeight = 12;
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
    
                for (int looper = 1; looper <= colCount; looper++)
                    workSheet.Cells[1, looper].Value = dt.Columns[looper - 1].ColumnName;
    
                for (int looper = 1; looper <= colCount; looper++)
                {
                    workSheet.Cells[1, looper].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[1, looper].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[1, looper].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[1, looper].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
    
                for (int rowNo = 0; rowNo < dt.Rows.Count; rowNo++)
                {
                    for (int colNo = 0; colNo < colCount; colNo++)
                        workSheet.Cells[rowNo + 2, colNo + 1].Value = dt.Rows[rowNo][colNo];
    
                    for (int innerLooper = 1; innerLooper <= colCount; innerLooper++)
                    {
                        workSheet.Cells[rowNo + 2, innerLooper].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[rowNo + 2, innerLooper].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[rowNo + 2, innerLooper].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        workSheet.Cells[rowNo + 2, innerLooper].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }
    
                for (int looper = 1; looper <= colCount; looper++)
                    workSheet.Column(looper).AutoFit();
    
                bytes = excel.GetAsByteArray();
    
                return bytes;
            }
    
            public static Byte[] GetBytes(string query)
            {
                Byte[] bytes;
                ReadData(query);
                bytes = PrepareByte(dtExcel);
                return bytes;
            }
    
    
            public static Byte[] GetBytes(DataTable dt)
            {
                Byte[] bytes;
                bytes = PrepareByte(dt);
                return bytes;
            }
        }
