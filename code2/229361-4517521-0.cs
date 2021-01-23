           string address;   
            string next;   
            try   
            {      
                Excel.ApplicationClass excel = new Excel.ApplicationClass();      
                object Missing = Type.Missing;
                FileInfo fInfo = new FileInfo(@"D:\sample.xls");  
                if(fInfo.Exists)            
                {       
                    Excel.Workbook workbook = excel.Workbooks.Open(@"D:\sample.xls", Missing, Missing,
                        Missing, Missing, Missing, Missing, Missing,     
                        Missing, Missing, Missing, Missing, Missing,    
                        Missing, Missing);           
                    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets["Sheet1"];
                    Excel.Range docNumber = worksheet.Cells.Find("DDEC", worksheet.Cells[1, 1],
                        Excel.XlFindLookIn.xlValues,   
                        Excel.XlLookAt.xlPart, Missing, Excel.XlSearchDirection.xlNext,  
                        false, Missing, Missing);  
                    if(docNumber != null)    
                    {             
                        address = docNumber.get_Address(true, true, Excel.XlReferenceStyle.xlA1, Missing,
                            Missing);        
                        docNumber = worksheet.UsedRange;  
                        for (int rCnt = 1; rCnt <= docNumber.Rows.Count; rCnt++)  
                        {                 
                            for (int cCnt = 1; cCnt <= docNumber.Columns.Count; cCnt++)  
                            {                
                                string str = (string)(docNumber.Cells[rCnt, cCnt] as Excel.Range).Value2;
                                MessageBox.Show(str); 
                            }         
                        }               
                        Console.WriteLine(address);   
                    }             
                }
              
        }
