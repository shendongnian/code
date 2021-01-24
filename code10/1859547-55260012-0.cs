    private static int GetRowExcel(string projectName)
        {
            int realrow = 0;
            using (MemoryStream stream = new MemoryStream(bin))
            using (ExcelPackage excelPackage = new ExcelPackage(stream))
            {
                var ws = excelPackage.Workbook.Worksheets["Work"];
                
                string nrNummer = projectName.Split(' ').First();
                for (int row = 5; ws.Cells[row, 5].Value != null; row++)
                {
                   if(ws.Cells[row, 5].Value.ToString()==nrNummer)
                    { realrow = row;
                    }
    
                }
            }
            return realrow; //The name'realrow' does not exist in the current context
        }
