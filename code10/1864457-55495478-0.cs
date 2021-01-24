        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        Microsoft.Office.Interop.Excel.Application excelApp;
        Workbook excelWorkBook;
        Worksheet excelWorkSheet;
       // Excel file opened inside panel control on button click event.
        private void btnLoadExcelParent_Click(object sender, EventArgs e)
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
          
            excelApp.Visible = true;
            excelApp.ScreenUpdating = true;
            excelApp.EnableAutoComplete = false;
            object misValue = System.Reflection.Missing.Value;
            excelWorkBook = excelApp.Workbooks.Add(misValue);            
            IntPtr excelHwnd = new IntPtr(excelApp.Application.Hwnd);
            SetParent(excelHwnd, panel1.Handle);
        }
