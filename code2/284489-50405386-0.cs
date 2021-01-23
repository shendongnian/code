    static void Main(string[] args)
            {
                string filepath = @"C:\test.xls";
                HSSFWorkbook hssfwb;
    
                using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }
    
                ISheet sheet = hssfwb.GetSheetAt(0);
    
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                    {
                        // Set new cell value
                        sheet.GetRow(row).GetCell(0).SetCellValue("foo");
                        Console.WriteLine("Row {0} = {1}", row, sheet.GetRow(row).GetCell(0).StringCellValue);
                    }
                }
    
                // Save the file
                using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Write))
                {
                    hssfwb.Write(file);
                }
    
                Console.ReadLine();
            }
