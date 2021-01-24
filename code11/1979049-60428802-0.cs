c# 
            Excel.Workbook xlWB = Globals.ThisAddIn.Application.ActiveWorkbook; // or other way you get an instance of the workbook 
            long pagesCount = 0;
            foreach (Excel.Worksheet xlSht in xlWB.Sheets)
            {
                if (xlSht.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                {
                    pagesCount += xlSht.PageSetup.Pages.Count;
                }
            }
            MessageBox.Show(pagesCount.ToString());
