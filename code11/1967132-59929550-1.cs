    public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                this.Application.WorkbookBeforeClose += ApplicationOnWorkbookBeforeClose;
            }
    
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
            
            // Catch the before close event
            private void ApplicationOnWorkbookBeforeClose(Excel.Workbook wb, ref bool cancel)
            {
    
                if (!wb.Saved)
                {
                    switch (MessageBox.Show(text:$"Do you want to save changes you made to '{this.Application.ActiveWorkbook.Name}'?", 
                        caption:"Microsoft Excel",buttons:MessageBoxButtons.YesNoCancel, icon:MessageBoxIcon.Exclamation))
                    {
                        case DialogResult.Cancel: // case want to cancel - break the closing event
                            {
                                cancel = true;
                                return;
                            }
                        case DialogResult.Yes: // case user want to save wb - save wb
                            {
                                wb.Save();
                                break;
                            }
                        case DialogResult.No: // case user don't want to save wb - mark wb as saved to avoid the application messagebox to appear
                            {
                                wb.Saved = true;
                                break;
                            }
                    }
                }
    
                if (IsAnyWorkbookOpen())
                {
                    // replace this with your code
                    MessageBox.Show("Some books will still be open, don't turn off the ribbon");
                    return;
                }
                // replace this with your code
                MessageBox.Show("All books will be closed");
            }
    
            private bool IsAnyWorkbookOpen()
            {
                // check that remaining amount of open workbooks without the one being closed is greater that 2
                if (this.Application.Workbooks.Count - 1 > 2)
                {
                    return true;
                }
                // IF the count of workbooks is 2 one of them maybe a PERSONAL.xlsb
                else if (this.Application.Workbooks.Count == 2)
                {
                    foreach (Excel.Workbook wb in this.Application.Workbooks)
                    {
                        if (!wb.Name.Equals(this.Application.ActiveWorkbook.Name))
                        {
                            // In case when one of two open workbooks is Personal macro book you may assume that 
                            // there will be no open workbooks for user to work directly
                            if (wb.Name.Equals("Personal.xlsb".ToUpper()))
                            {
                                return false;
                            }
                        }
                    }
                    // In case when NONE of two open workbooks is a Personal macro book
                    // there will be at least one open workbook for user to work directly
                    return true;
                }
                else
                {
                    return true;
                }
            }
    
    
            #region VSTO generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InternalStartup()
            {
                this.Startup += new System.EventHandler(ThisAddIn_Startup);
                this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
            
            #endregion
        }
