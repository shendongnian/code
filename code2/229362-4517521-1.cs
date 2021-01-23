          using Excel = Microsoft.Office.Interop.Excel;
           string address;
                Excel.ApplicationClass excel = new Excel.ApplicationClass();
                object Missing = Type.Missing;
                FileInfo fInfo = new FileInfo(@"D:\Book1.xls");
                if (fInfo.Exists)
                {
                    Excel.Workbook workbook = excel.Workbooks.Open(@"D:\Book1.xls", Missing, Missing,
                        Missing, Missing, Missing, Missing, Missing,
                        Missing, Missing, Missing, Missing, Missing,
                        Missing, Missing);
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];
                    Excel.Range docNumber = worksheet.Cells.Find("10/5/2010", worksheet.Cells[1, 1],
                        Excel.XlFindLookIn.xlValues,
                        Excel.XlLookAt.xlPart, Missing, Excel.XlSearchDirection.xlNext,
                        false, Missing, Missing);
                    if (docNumber != null)
                    {
                        address = docNumber.get_Address(true, true, Excel.XlReferenceStyle.xlA1, Missing,
                            Missing);
                        docNumber = worksheet.UsedRange;
                        DateTime parsedDate;                       
                        for (int rCnt = 1; rCnt <= docNumber.Rows.Count; rCnt++)
                        {
                            for (int cCnt = 1; cCnt <= docNumber.Columns.Count; cCnt++)
                            {
                                string str = (string)(docNumber.Cells[rCnt, cCnt] as Excel.Range).Text ;
                                parsedDate = DateTime.Parse(str);
                                str =  String.Format("{0:dd-mm-yyyy}", parsedDate);
                                docNumber.Cells[rCnt, cCnt] = str;                                
                            }
                        }                        
                        workbook.Save();                        
                    }
                }
