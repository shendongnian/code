     public  void DefaultSaveExcel(Workbook wb, ref bool Cancel)
        {
            while (wb.Saved == false && Cancel == false)
            {
                var result = ShowMessageDialogSave();
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    var sa = CreateExcelSaveDialog(wb.FullName);
                    if (sa.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        wb.SaveAs(sa.FileName);
                        wb.Save();
                    }
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                {
                    wb.Saved = true;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Cancel = true;
                }
            }
        }
        public  System.Windows.Forms.SaveFileDialog CreateExcelSaveDialog(string name = null)
        {
            var sa = new System.Windows.Forms.SaveFileDialog();
            sa.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (!string.IsNullOrEmpty(name))
                sa.FileName = name;
            sa.CreatePrompt = true;
            return sa;
        }
        public  DialogResult ShowMessageDialogSave()
        {
            var app = (Microsoft.Office.Interop.Excel.Application)ExcelDna.Integration.ExcelDnaUtil.Application;
            NativeWindow xlMain = new NativeWindow();
            xlMain.AssignHandle(new IntPtr(app.Hwnd));
           
            var message = "Do you want to save pending changes?";
            if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName.ToLower() == "es")
                message = "¿Desea guardar los cambios pendientes?";
            
                        
            return System.Windows.Forms.MessageBox.Show(xlMain, message, "Microsoft Excel", System.Windows.Forms.MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
        }
