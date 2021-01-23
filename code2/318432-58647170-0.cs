    using wf = System.Windows.Forms;
    using xl = Microsoft.Office.Interop.Excel;
    
        public static bool IsXlFileOpen(string xlFileName)
        {
    		xl.Application xlApp = null;
    		xl.Workbook xlWb = null;
    		xl.Worksheet xlWs = null;
    		
            try
            {		
    			if (!File.Exists(xlFileName))
    			{
    				wf.MessageBox.Show("Excel File does not exists!");
    				return false;
    			}
    
                try
                {
                    xlApp = (xl.Application)Marshal.GetActiveObject("Excel.Application");
                }
                catch (Exception ex)
                {
                    return false;
                }
    
                foreach (xl.Workbook wb in xlApp.Workbooks)
                {
                    if (wb.FullName == xlFileName)
                    {
                        xlWb = wb;
                        return true;
                    }
                }
    
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
