    public ArrayList ProcessWorkbook(string filePath)
            {
                string file = filePath;
    
                Excel.Application excel = null;
                Excel.Workbook wkb = null;
                ArrayList al = new ArrayList();
                try
                {
                    excel = new Excel.Application();
    
                    wkb = ExcelTools.OpenBook(excel, file, false, true, false);
    
                    Excel.Worksheet sheet = wkb.Sheets["Adresses"] as Excel.Worksheet;
    
                    Excel.Range range = null;
    
                    if (sheet != null)
                        range = sheet.get_Range("A1:X6702", Missing.Value);
    
    
                    if (range != null)
                    {
                        foreach (Excel.Range r in range)
                        {
                            al.Add(r.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //if you need to handle stuff
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (wkb != null)
                        ExcelTools.ReleaseRCM(wkb);
    
                    if (excel != null)
                        ExcelTools.ReleaseRCM(excel);
                }
                return al;
            }
    
    //----------------
        public static class ExcelTools
        {
            public static Excel.Workbook OpenBook(Excel.Application excelInstance, string fileName, bool readOnly, bool editable,
            bool updateLinks)
            {
                Excel.Workbook book = excelInstance.Workbooks.Open(
                    fileName, updateLinks, readOnly,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                return book;
            }
    
            public static void ReleaseRCM(object o)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
                }
                catch
                {
                }
                finally
                {
                    o = null;
                }
            }
        }
