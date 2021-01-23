    using System;
    using System.Collections.Generic;
    using System.IO;
    
    using Microsoft.Office.Interop.Excel;
    
    namespace ExcelInterop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application app = new Application();
                try
                {
                    FileInfo fiSource = new FileInfo(args[0]);
                    FileInfo fiDest = new FileInfo(args[1]);
                    Workbook wb = app.Workbooks.Open(fiSource.FullName,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    Worksheet sheet = (Worksheet)wb.Sheets[1];
    
                    Dictionary<string, DateTime> hashNewest = new Dictionary<string, DateTime>();
                    for (int iRow = 1; iRow < (double)sheet.Cells.Height; ++iRow )
                    {
                        object oID = sheet.get_Range("A" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        if (oID == null || oID.ToString().Trim().Length <= 0)
                            break;
    
                        object oName = sheet.get_Range("B" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        string strName = "" + oName;
                        object oDate = sheet.get_Range("C" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        DateTime dt = Convert.ToDateTime(oDate);
                        if( !hashNewest.ContainsKey(strName) )
                            hashNewest.Add(strName, dt);
                        else if (hashNewest[strName].CompareTo(dt) < 0)
                            hashNewest[strName] = dt;
                    }
    
                    for (int iRow = 1; iRow < (double)sheet.Cells.Height; ++iRow)
                    {
                        object oID = sheet.get_Range("A" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        if (oID == null || oID.ToString().Trim().Length <= 0)
                            break;
    
                        object oName = sheet.get_Range("B" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        string strName = "" + oName;
                        object oDate = sheet.get_Range("C" + (iRow + 1), Type.Missing).get_Value(Type.Missing);
                        DateTime dt = Convert.ToDateTime(oDate);
                        if (!hashNewest[strName].Equals(dt))
                        {
                            sheet.get_Range(
                                string.Format("A{0}:D{0}", iRow+1),
                                Type.Missing
                                ).Delete(XlDeleteShiftDirection.xlShiftUp);
                            --iRow;
                        }
                    }
    
                    File.Delete(fiDest.FullName);
                    wb.SaveAs(fiDest.FullName, Type.Missing, Type.Missing, Type.Missing, 
                        Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, 
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing );
                    
                    wb.Close(false, Type.Missing, Type.Missing);
                }
                finally
                {
                    app.Workbooks.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                }
                Console.WriteLine("Hit any key to continue");
                Console.ReadKey();
            }
        }
    }
