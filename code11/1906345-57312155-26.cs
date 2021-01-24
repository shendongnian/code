    System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.IO;
    using System.Diagnostics;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Data;
     
    namespace ConsoleApplication1 {
        class Program {
     
            static void Main(string[] args) {
     
                Excel.Application objApp;
                Excel.Workbook objBook;
                Excel.Sheets objSheets;
                Excel.Workbooks objBooks;
     
                string command = (@"SELECT * FROM dbo.Client");
     
                using (SqlConnection connection = new SqlConnection(GetConnectionStringByName("CubsPlus"))) {
                    DataTable data = new DataTable();
                    try {
                        connection.Open();
                    }
                    catch (Exception e) {
                        StackTrace st = new StackTrace(new StackFrame(true));
                        StackFrame sf = st.GetFrame(0);
                        Console.WriteLine (e.Message + "\n" + "Method" + sf.GetMethod().ToString() + "\n" + "Line" + sf.GetFileLineNumber().ToString());
                    }
                    try {
                        data = DataTools.SQLQueries.getDataTableFromQuery(connection, command);
     
                        if (data == null) {
                            throw new ArgumentNullException();
                        }
                    }
                    catch (Exception e) {
                        StackTrace st = new StackTrace(new StackFrame(true));
                        StackFrame sf = st.GetFrame(0);
                        Console.WriteLine (e.Message + "\n" + "Method" + sf.GetMethod().ToString() + "\n" + "Line" + sf.GetFileLineNumber().ToString());
                    }
     
                    objApp = new Excel.Application();
                    try {     
                        objBooks = objApp.Workbooks;
                        objBook = objApp.Workbooks.Add(Missing.Value);
                        objSheets = objBook.Worksheets;
     
                        Excel.Worksheet sheet1 = (Excel.Worksheet)objSheets[1];
                        sheet1.Name = "ACCOUNTS";
                        string message = DataTools.Excel.copyDataTableToExcelSheet(data, sheet1);
                        if (message != null) {
                            Console.WriteLine("Problem importing the data to Excel");
                            Console.WriteLine(message);
                            Console.ReadLine();
                        }
                             
                        //CREATE A PIVOT CACHE BASED ON THE EXPORTED DATA
                        Excel.PivotCache pivotCache = objBook.PivotCaches().Add(Excel.XlPivotTableSourceType.xlDatabase,sheet1.UsedRange);
     
                        Console.WriteLine(pivotCache.SourceData.ToString());
                        
                        Console.ReadLine();
     
                        //WORKSHEET FOR NEW PIVOT TABLE
                        Excel.Worksheet sheet2 = (Excel.Worksheet)objSheets[2];
                        sheet2.Name = "PIVOT1";
                        
                        //PIVOT TABLE BASED ON THE PIVOT CACHE OF EXPORTED DATA
                        Excel.PivotTables pivotTables = (Excel.PivotTables)sheet2.PivotTables(Missing.Value);
                        Excel.PivotTable pivotTable = pivotTables.Add(pivotCache, objApp.ActiveCell, "PivotTable1", Missing.Value, Missing.Value);
     
                        pivotTable.SmallGrid = false;
                        pivotTable.TableStyle = "PivotStyleLight1";
     
                        //ADDING PAGE FIELD
                        Excel.PivotField pageField = (Excel.PivotField)pivotTable.PivotFields("ParentName");
                        pageField.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
     
                        //ADDING ROW FIELD
                        Excel.PivotField rowField = (Excel.PivotField)pivotTable.PivotFields("State");
                        rowField.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
     
                        //ADDING DATA FIELD
                        pivotTable.AddDataField(pivotTable.PivotFields("SetupDate"), "average setup date", Excel.XlConsolidationFunction.xlAverage);
     
                        ExcelSaveAs(objApp, objBook, @"J:\WBK");
     
                        objApp.Quit();
                    }     
                    catch (Exception e) {
                        objApp.Quit();
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
     
            static string ExcelSaveAs(Excel.Application objApp, Excel.Workbook objBook, string path) {
                try {
                    objApp.DisplayAlerts = false;
                    objBook.SaveAs(path, Excel.XlFileFormat.xlExcel7, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    objApp.DisplayAlerts = true;
                    return null;
                }
                catch (Exception e) {
                    StackTrace st = new StackTrace(new StackFrame(true));
                    StackFrame sf = st.GetFrame(0);
                    return (e.Message + "\n" + "Method" + sf.GetMethod().ToString() + "\n" + "Line" + sf.GetFileLineNumber().ToString());
                }
            }
            static string GetConnectionStringByName(string name) {
                //ASSUME FAILURE
                string returnValue = null;
     
                //Look for the name in the connectionStrings section
                ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
     
                // If found, return the connection string
                if (settings != null) {
                    returnValue = settings.ConnectionString;
                }
                return returnValue;
            }
        }
    }
