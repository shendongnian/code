     using ClosedXML.Excel;
     DataTable DT = MyDataTable;
     XLWorkbook wb = new XLWorkbook();
     IXLWorksheet UseLevelDataSheet= wb.Worksheets.Add(DT, "BootStrap Uselevel 
    Data");
            IXLWorksheet MLE_EstimatesSheet= wb.Worksheets.Add(DT_estimates, "MLE estimates & CB_BCA");
            
            if (SavePath==null)
            {
                string DocFolder = 
    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string FileName = CreateFileName(DocFolder);
                wb.SaveAs(FileName);
                SavePath = FileName;
            }
            else
            {
                try
                {
                    wb.SaveAs(SavePath);
                }
                catch (Exception err)
                {
                    if (err.HResult== -2147024864)
                    {
                        MessageBox.Show("Unable save, file is locked!");
                    }
                    
                }
                
            }
