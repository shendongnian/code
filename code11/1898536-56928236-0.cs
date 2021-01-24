    //MICROSOFT WORD INTEGRATION
            try
            {
                app = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                app.ActiveWindow.Selection.Font.Color = (Microsoft.Office.Interop.Word.WdColor)(changeColor.R + 0x100 * changeColor.G + 0x10000 * changeColor.B);
            }
            catch (System.Exception excp)
            {
            }
            //MICROSOFT EXCEL INTEGRATION
            try
            {
                xlApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                xlBook = xlApp.ActiveWorkbook;
                xlSheet = xlBook.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range rngSelection = xlApp.Selection as Microsoft.Office.Interop.Excel.Range;
                for (var r = 1; r <= rngSelection.Rows.Count; r++)
                {
                    for (var c = 1; c <= rngSelection.Columns.Count; c++)
                    {
                        rngSelection[r, c].Font.Color = copyProgramText.SelectionColor;
                    }
                }
            }
            catch (System.Exception excp)
            {
            }
            //MICROSOFT POWERPOINT INTEGRATION
            try
            {
                pwptApp = (Microsoft.Office.Interop.PowerPoint.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("PowerPoint.Application");
                pwptApp.ActiveWindow.Selection.TextRange.Font.Color.RGB = System.Drawing.ColorTranslator.ToOle(changeColor);
                if (pwptApp.ActiveWindow.Selection.TextRange.Text.Trim() == "") pwptApp.ActiveWindow.Selection.TextRange.Text = " ";
            }
            catch (System.Exception excp)
            {
            }
            //MICROSOFT OUTLOOK INTEGRATION
            try
            {
                Microsoft.Office.Interop.Outlook.Application otlkApp = (Microsoft.Office.Interop.Outlook.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Outlook.Application");
                Microsoft.Office.Interop.Outlook.Explorer otlkExp = otlkApp.ActiveExplorer();
                Microsoft.Office.Interop.Outlook.Selection otlkSel = otlkExp.Selection;
                Microsoft.Office.Interop.Outlook.MailItem otlkMsg = otlkApp.ActiveInspector().CurrentItem as Microsoft.Office.Interop.Outlook.MailItem;
                Microsoft.Office.Interop.Outlook.Inspector insp = otlkMsg.GetInspector;
                Microsoft.Office.Interop.Word.Document otlkDoc = (Microsoft.Office.Interop.Word.Document)insp.WordEditor;
                string sepSel = otlkDoc.Application.Selection.Text;
                byte rColor = changeColor.R;
                byte gColor = changeColor.G;
                byte bColor = changeColor.B;
                if (sepSel.Trim() == "\r") return;
                char cReturn = (char)13;
                if (sepSel == cReturn.ToString()) return;
                if (sepSel != "")
                {
                    otlkMsg.HTMLBody = otlkMsg.HTMLBody.Replace(sepSel, "<font style = 'color: rgb(" + rColor.ToString() + ", " + gColor.ToString() + ", " + bColor.ToString() + ")'>" + sepSel + " </font>");
                }
                else
                {
                    return;
                }
                prevOutlookContents = otlkMsg.HTMLBody;
            }
            catch (System.Exception excp)
            {
            }
