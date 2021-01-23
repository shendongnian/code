     using Microsoft.Office.Interop.Excel;
     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using excel = Microsoft.Office.Interop.Excel;
     using System.IO;
     using System.Data;
     using System.Windows.Forms;
     using System.Runtime.InteropServices;
     //class and namespace wrapper is not shown in this example 
     private void WriteToExcel(System.Data.DataTable dt, string location)
        {
            //instantiate excel objects (application, workbook, worksheets)
            excel.Application XlObj = new excel.Application();
            XlObj.Visible = false;
            excel._Workbook WbObj = (excel.Workbook)(XlObj.Workbooks.Add(""));
            excel._Worksheet WsObj = (excel.Worksheet)WbObj.ActiveSheet;
          
            //run through datatable and assign cells to values of datatable
            try
            {
                int row = 1; int col = 1;
                foreach (DataColumn column in dt.Columns)
                {
                    //adding columns
                    WsObj.Cells[row, col] = column.ColumnName;
                    col++;
                }
                //reset column and row variables
                col = 1;
                row++;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //adding data
                    foreach (var cell in dt.Rows[i].ItemArray)
                    {
                        WsObj.Cells[row, col] = cell;
                        col++;
                    }
                    col = 1;
                    row++;
                }
                WbObj.SaveAs(location);
            }
            catch (COMException x)
            {
                MessageBox.Show(x.Message);
                ErrorHandler.Handle(x);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ErrorHandler.Handle(ex);
            }
            finally
            {
                WbObj.Close();                
            }
        }
