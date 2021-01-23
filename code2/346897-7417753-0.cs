        // Available at the class level. single instance - Singleton pattern may be employed
        // Check the correct datatype for ExcelSheet
        ExcelSheet sheet;
        void UpdateExcelSheet(int row, int col, string value)
        {
            if (sheet == null)
            {
                var xl = new Excel.Application();
                xl.Visible = true;
                var wb = (Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
                sheet = (Excel._Worksheet)wb.ActiveSheet;
            }
            sheet.Cells[row, col] = value;
        }
        void OnComboSelection()
        {
            int row, col;
            string value;
            if(comboBox5.Text == "1")
            {
                row = 6; col = 6; value = "1";
            }
            if (comboBox3.Text == "2")
            {
                row = 6; col = 8; value = "2";
            }
            UpdateExcelSheet(row, col, value);
        }
